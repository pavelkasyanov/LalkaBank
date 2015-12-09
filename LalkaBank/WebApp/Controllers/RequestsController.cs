using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public RequestsController(IRequestService requestService, 
            ICreditTypesService creditTypesService)
        {
            _requestService = requestService;
            _creditTypesService = creditTypesService;
        }

        // GET: Requests
        public ActionResult Index(int? page)
        {
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
            var model = new CreateRequestViewModel()
            {
                CreditTypes = GetCreditTypes()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateRequestViewModel viewModel)
        {
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
                StartSum = viewModel.StartSum
            };

            _requestService.Create(request);

            ViewBag.Result = true;
            ViewBag.ResultMsg = "Done";

            return View(viewModel);
        }

        public ActionResult Show(Guid id)
        {
            var model = GetRequestViewModel(id);

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
                RequestId = request.Id,
                CreditInfo = request.CreditInfo,
                Confirm = request.Confirm,
                Number = request.Number,
                IncomeImage = request.IncomeImage,
                CreditType = new CreditTypeViewModel()
                {
                    CreditTypesId = creaditType.Id,
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
            if (ost != 0)
            {
                allPageCount++;
            }

            int selectCount = ( (pageNumber >= allPageCount && ost != 0) ?  ost : itemsInPage);

            list = list.OrderBy(x => x.Number).ToList();
            list = list.GetRange(startRange, selectCount);

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