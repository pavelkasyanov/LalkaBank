using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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

        public RequestsController(IRequestService requestService, 
            ICreditTypesService creditTypesService, 
            IPersonService personService)
        {
            _requestService = requestService;
            _creditTypesService = creditTypesService;
            _personService = personService;
        }

        // GET: Requests
        public ActionResult Index(int? page)
        {
            var user = _personService.Get(Guid.Parse(User.Identity.GetUserId()));

            if (user == null)
            {
                ViewBag.isUserNotRegister = true;
            }

            if (user != null && user.IsBanned)
            {
                ViewBag.isUserBanned = true;
            }

            var viewModel = GetRequestsViewModelFromPage(page ?? 1);
            if (viewModel == null)
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "error load requests";
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
                CreditTypes = GetCreditTypes()
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
                Date = DateTime.Now
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

        public ActionResult Show(Guid id)
        {
            var model = GetRequestViewModel(id);

            Thread.Sleep(1000);

            return PartialView("ShowPartial", model);
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
            ResultFindRequestsViewModel viewModel = new ResultFindRequestsViewModel()
            {
                //Requests = new List<SelectListItem>()
            };

            //if (model.ItemsPerPage = 0)
            {
                viewModel = this.FindRequestsViewModelFromPage(model.CurrentPageNumber, model.Start, model.End);
            }

            return View(viewModel);
        }

        //============================

        private IEnumerable<SelectListItem> GetCreditTypes()
        {
            return _requestService.GetCreditTypes().Select(
                role => new SelectListItem() { Text = role.Info, Value = role.Id.ToString() })
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
                CreditType = new CreditTypeViewModel()
                {
                    Id = creaditType.Id,
                    Info = creaditType.Info,
                    PayCount = creaditType.PayCount,
                    Percent = creaditType.PayCount,
                    StartSumPercent = creaditType.StartSumPercent
                },
                UserInfo = new UserInfoPartialViewModel()
                {
                    Name = request.Persons.Name,
                    SecondName = request.Persons.SecondName,
                    LastName = request.Persons.LastName,
                    Email = request.Persons.Login,
                    DateBirth = request.Persons.DateBirth ?? new DateTime(),
                    CreditHistoryIndex = request.Persons.CreditHistoryIndex
                }
                
            };

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
            list = list.OrderBy(x => x.Date).ToList();

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
            if (list == null)
            {
                return null;
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
                ItemsPerPage = itemsInPage
            };

            return model;
        }
    }
}