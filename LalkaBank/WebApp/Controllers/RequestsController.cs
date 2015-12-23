using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAO;
using Microsoft.AspNet.Identity;
using WebApp.Models;
using WebApp.Models.Domains.Credits;
using WebApp.Models.Domains.Requests;
using WebApp.Models.Domains.Users;

namespace WebApp.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly ICreditTypesService _creditTypesService;
        private readonly IPersonService _personService;
        private readonly IBankAccountService _accountService;
        private readonly IManagerService _managerService;
        private readonly ICreditService _creditService;

        public RequestsController(IRequestService requestService, 
            ICreditTypesService creditTypesService, 
            IPersonService personService, 
            IBankAccountService accountService, 
            IManagerService managerService, 
            ICreditService creditService)
        {
            _requestService = requestService;
            _creditTypesService = creditTypesService;
            _personService = personService;
            _accountService = accountService;
            _managerService = managerService;
            _creditService = creditService;
        }

        // GET: Requests
        public ActionResult Index(int? page)
        {
            if (User.IsInRole("User"))
            {
                if (!_personService.IsUserRegister(Guid.Parse(User.Identity.GetUserId())))
                {
                        ViewBag.isUserNotRegister = true;
                }
                else
                {
                    var user = _personService.Get(Guid.Parse(User.Identity.GetUserId()));
                    if (user != null && user.IsBanned)
                    {
                        ViewBag.isUserBanned = true;
                    }
                }

            } else if (User.IsInRole("Manager"))
            {
                if (!_managerService.IsManagerRegister(Guid.Parse(User.Identity.GetUserId())))
                {
                    ViewBag.isManagerNotRegister = false;
                }
            }
            else
            {
            }

            var viewModel = GetRequestsViewModelFromPage(page ?? 1);
            if (viewModel == null)
            {
                ViewBag.Result = false;
            }

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var user = _personService.Get(Guid.Parse(User.Identity.GetUserId()));
            if (user == null)
            {
                ViewBag.Resull = false;
                ViewBag.ResultMsg = "edit your info";

                return RedirectToAction("UserInfo", "User");
            }

            if (user.IsBanned)
            {
                ViewBag.isUserBanned = true;
            }

            var model = new CreateRequestViewModel()
            {
                CreditTypes = GetCreditTypes(),
                FamilyStatusList = new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "0", Text = "married" },
                    new SelectListItem() { Value = "1", Text = "single" }
                },
                EducationList = new List<SelectListItem>()
                {
                   new SelectListItem() { Value = "0", Text = "higher" },
                   new SelectListItem() { Value = "1", Text = "secondary special" },
                   new SelectListItem() { Value = "2", Text = "secondary" }
                },
                WorkChangeCountList = new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "0", Text = "no one" },
                    new SelectListItem() { Value = "1", Text = "once" },
                    new SelectListItem() { Value = "2", Text = "more than one time" }
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateRequestViewModel viewModel)
        {

            var user = _personService.Get(Guid.Parse(User.Identity.GetUserId()));
            if (user == null)
            {
                ViewBag.Resull = false;
                ViewBag.ResultMsg = "edit your info";

                RedirectToAction("UserInfo", "User");
            }

            viewModel.CreditTypes = GetCreditTypes();
            viewModel.FamilyStatusList = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "0", Text = "married"},
                new SelectListItem() {Value = "1", Text = "single"}
            };
            viewModel.EducationList = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "0", Text = "higher"},
                new SelectListItem() {Value = "1", Text = "secondary special"},
                new SelectListItem() {Value = "2", Text = "secondary"}
            };
            viewModel.WorkChangeCountList = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "0", Text = "no one"},
                new SelectListItem() {Value = "1", Text = "once"},
                new SelectListItem() {Value = "2", Text = "more than one time"}
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            byte[] incomeImage = null;
            if (viewModel.IncomeImage != null)
            {
                var fileLen = viewModel.IncomeImage.ContentLength;
                incomeImage = new byte[fileLen];
                viewModel.IncomeImage.InputStream.Read(incomeImage, 0, fileLen);
            }

            var request = new Request
            {
                CreditTypeId = viewModel.CreditTypeId,
                CreditInfo = viewModel.CreditInfo,
                PersonId = Guid.Parse(User.Identity.GetUserId()),
                IncomeImage = incomeImage,
                StartSum = viewModel.StartSum,
                Date = _creditService.GetTimeTable().Date,
                ScoringIndex = GetScoringIndexForRequest(viewModel)
            };

            var result = _requestService.Create(request);

            if (result)
            {
                ViewBag.Result = true;
                ViewBag.ResultMsg = "Done";
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "Error";
            }

            return View(viewModel);
        }

        public ActionResult Show(Guid? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var model = GetRequestViewModel(id.Value);

            return View(model);
        }

        //Подтвердить заявку
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult ConfirmRequest(Guid id)
        {
            ViewBag.Result = "Confirm suc!";
            var msg = "Confirm suc!";
            _requestService.ConfirmRequest(id, Guid.Parse(User.Identity.GetUserId()), msg);

            return RedirectToAction("Create", "Credits", new {requestId = id});
        }

        //Отказать заявку
        [Authorize(Roles = "Manager")]
        public ActionResult DiscartRequest(Guid id)
        {
            ViewBag.Result = "Discart suc!";

            var msg = "Discart suc!";
            _requestService.DiscartRequest(id, Guid.Parse(User.Identity.GetUserId()), msg);

            return RedirectToAction("Show", new { id = id});
        }

        public ActionResult Find(ResultFindRequestsViewModel model)
        {
            var viewModel = FindRequestsViewModelFromPage(model.CurrentPageNumber, model.Start, model.End);

            return View(viewModel);
        }

        //============================

        private IEnumerable<SelectListItem> GetCreditTypes()
        {
            return _requestService.GetCreditTypes().Select(
                role => new SelectListItem() { Text = role.Name, Value = role.Id.ToString() })
                .ToList();
        }

        private RequestViewModel GetRequestViewModel(Guid id)
        {
            var request = _requestService.Get(id);
            var creaditType = _creditTypesService.Get(request.CreditTypeId);

            var model = new RequestViewModel
            {
                Id = request.Id,
                CreditInfo = request.CreditInfo,
                Confirm = request.Confirm,
                Number = request.Number,
                IncomeImage = request.IncomeImage,
                Date = request.Date,
                ScoringIndex = request.ScoringIndex,
                CreditType = new CreditTypeViewModel()
                {
                    Id = creaditType?.Id ?? Guid.Empty,
                    Info = creaditType?.Info ?? "",
                    PayCount = creaditType?.PayCount ?? 0,
                    Percent = creaditType?.PayCount ?? 0,
                    StartSumPercent = creaditType?.StartSumPercent ?? 0
                },
                UserInfo = new UserInfoPartialViewModel()
                {
                    Id = request.Persons.Id,
                    Name = request.Persons.Name,
                    SecondName = request.Persons.SecondName,
                    LastName = request.Persons.LastName,
                    Email = request.Persons.Login,
                    DateBirth = request.Persons.DateBirth ?? new DateTime(),
                    CreditHistoryIndex = request.Persons.CreditHistoryIndex
                }
                
            };

            var  account = _accountService.Get();
            account.Amount -= request.StartSum;
            _accountService.CreateOrUpdate(account);

            return model;
        }

        private ResultFindRequestsViewModel FindRequestsViewModelFromPage(int pageNumber, DateTime start, DateTime end)
        {
            int itemsInPage = 10;

            List<Request> list = null;
            list = User.IsInRole("User") ?
                _requestService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _requestService.GetList();
            if (list == null)
            {
                return null;
            }

            list = list.Where(x => x.Date >= start && x.Date <= end).ToList();
            list = list.OrderBy(x => x.Number).ToList();

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count / itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ((pageNumber >= allPageCount && ost != 0) ? ost : itemsInPage);

            if (list.Count != 0)
            {
                list = list.GetRange(startRange, selectCount);
            }

            var model = new ResultFindRequestsViewModel()
            {
                Requests = list.Select(
                request => new RequestViewModel()
                {
                    CreditInfo = request.CreditInfo,
                    Id = request.Id,
                    Date = request.Date
                }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                Start = start,
                End = end
            };

            return model;
        }

        private RequestsViewModel GetRequestsViewModelFromPage(int pageNumber)
        {
            int itemsInPage = 10;

            List<Request> list = null;
            list = User.IsInRole("User") ?
                _requestService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _requestService.GetList();
            list = list.Where(x => x.Confirm == 0).ToList();
            if (list.Count == 0)
            {
                var viewModel = new RequestsViewModel()
                {
                    CurrentPageNumber = pageNumber,
                    AllPageCount = 1,
                    ItemsPerPage = itemsInPage,
                    IsRequestExist = false
                };

                return viewModel;
            }

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count/itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ( (pageNumber >= allPageCount && ost != 0) ?  ost : itemsInPage);

            if (list.Count != 0)
            {
                list = list.OrderBy(x => x.Number).ToList();
                list = list.GetRange(startRange, selectCount);
            }
            
            var model = new RequestsViewModel()
            {
                Requests = list.Select(
                request => new SelectListItem()
                {
                    Text = request.CreditInfo,
                    Value = request.Id.ToString()
                }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                IsRequestExist = true
            };

            return model;
        }

        private int GetScoringIndexForRequest(CreateRequestViewModel viewModel)
        {
            int scoringIndex = 0;

            var person = _personService.Get(Guid.Parse(User.Identity.GetUserId()));
            if (person == null)
            {
                return -100;
            }

            scoringIndex = (int)(person.CreditHistoryIndex * (-0.2));

            var bday = person.DateBirth.Value;
            var today = _creditService.GetTimeTable().Date;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;


            //Scoring Age
            if (age < 24)
            {
                scoringIndex += -5;
            } else if (age >= 24 && age <= 40)
            {
                scoringIndex += 5;
            } else if (age > 40)
            {
                scoringIndex += 3;
            }

            //Family status
            switch (viewModel.FamilyStatus)
            {
                case 0:
                    scoringIndex += 3;
                    break;
                case 1:
                    scoringIndex += -2;
                    break;
            }

            //Have children
            if (viewModel.HaveChildren)
            {
                scoringIndex += 3;
            }
            else
            {
                scoringIndex += -1;
            }

            //Education
            switch (viewModel.Education)
            {
                case 0:
                    scoringIndex += 5;
                    break;
                case 1:
                    scoringIndex += 4;
                    break;
                case 2:
                    scoringIndex += 0;
                    break;
            }

            //have vehicle

            if (viewModel.HaveVehicle)
            {
                scoringIndex += 3;
            }
            else
            {
                scoringIndex += 0;
            }

            //Work Expireance

            if (viewModel.WorkExperience < 3)
            {
                scoringIndex += -1;

            } else if (viewModel.WorkExperience >=3 && viewModel.WorkExperience <= 10)
            {
                scoringIndex += -3;

            } else if (viewModel.WorkExperience > 10)
            {
                scoringIndex += -4;
            }

            //Work change count 
            switch (viewModel.WorkChangeCount)
            {
                case 0:
                    scoringIndex += 4;
                    break;
                case 1:
                    scoringIndex += 1;
                    break;
                case 2:
                    scoringIndex += -2;
                    break;
            }



            return scoringIndex;
        }

    }
}