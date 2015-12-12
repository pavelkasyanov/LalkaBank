using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using Services.Interfaces;
using WebApp.Models.Domains.Credits;

namespace WebApp.Controllers
{
    public class CreditTypesController : Controller
    {
        private readonly ICreditTypesService _creditTypesService;

        public CreditTypesController(ICreditTypesService creditTypesService)
        {
            _creditTypesService = creditTypesService;
        }

        // GET: CreditTypes
        public ActionResult Index(CreditTypesViewModel model)
        {
            var viewModel = GetCreditTypesViewModelForPage(model.CurrentPageNumber,
                model.PercentFrom, model.PercentTo,
                model.PayCountFrom, model.PayCountTo);

            if (viewModel.SearchResult == false)
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "error load requests";
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreditTypeViewModel();

            return PartialView("CreatePartial", viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreditTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("CreatePartial", viewModel);
            }

            var creditType = new CreditType()
            {
               Id = Guid.NewGuid(),
               Created = DateTime.Now,
               Name = viewModel.Name,
               Percent = viewModel.Percent,
               PayCount = viewModel.PayCount,
               StartSumPercent = viewModel.StartSumPercent,
               Info = viewModel.Info,
               Active = true
            };

            var res = _creditTypesService.Create(creditType);
            if (res)
            {
                ViewBag.Result = true;
                ViewBag.ResultMsg = "credit type created";
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "credit type not created";
            }

            return PartialView("CreatePartial", viewModel);
        }

        public ActionResult Show(Guid id)
        {
            var creditType = _creditTypesService.Get(id);
            var viewModel = new CreditTypeViewModel()
            {
                Id = creditType.Id,
                Name = creditType.Name,
                Percent = creditType.Percent,
                StartSumPercent = creditType.StartSumPercent,
                PayCount = creditType.PayCount,
                Info = creditType.Info,
                IsActive = creditType.Active
            };

            return PartialView("ShowPartial", viewModel);
        }

        public ActionResult Freeze(Guid creditTypeId, bool isActive)
        {
            var creditType = _creditTypesService.Get(creditTypeId);
            if (creditType == null)
            {
                return Json(new {result = false, msg = "credit type not fount", active = !isActive}, JsonRequestBehavior.AllowGet);
            }

            creditType.Active = isActive;
            if (_creditTypesService.Create(creditType))
            {
                return Json(new
                {
                    result = true,
                    msg = isActive ? "credit type active" : "credit type not active",
                    active = isActive
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {result = false, msg = "unknown error", Active = !isActive }, JsonRequestBehavior.AllowGet);
            }
        }

        private CreditTypesViewModel GetCreditTypesViewModelForPage(int pageNumber, 
            double percentFrom, double percentTo, 
            int payCountFrom, int payCountTo)
        {
            int itemsInPage = 10;

            var list = _creditTypesService.GetList();

            {
                var tPercentFrom = (percentFrom != 0 ? percentFrom : double.MinValue);
                var tPercentTo = (percentTo != 0 ? percentTo : double.MaxValue);
                var tPayCountFrom = (payCountFrom != 0 ? payCountFrom : int.MinValue);
                var tPayCountTo = (payCountTo != 0 ? payCountTo : int.MaxValue);

                list = list.Where(x => x.Percent >= tPercentFrom && x.Percent <= tPercentTo).ToList();
                list = list.Where(x => x.PayCount >= tPayCountFrom && x.PayCount <= tPayCountTo).ToList();
            }
            if (list.Count == 0)
            {
                return new CreditTypesViewModel()
                {
                    SearchResult = false
                };
            }

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count / itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ((pageNumber >= allPageCount && ost != 0) ? ost : itemsInPage);

            if (list.Count != 0)
            {
                list = list.OrderBy(x => x.Created).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var viewModel = new CreditTypesViewModel()
            {
                CreditTypes = list.Select(
                    creditType => new CreditTypeViewModel()
                    {
                        Id = creditType.Id,
                        Name = creditType.Name,
                        Percent = creditType.Percent,
                        StartSumPercent = creditType.StartSumPercent,
                        PayCount = creditType.PayCount,
                        Info = creditType.Info
                    }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                PayCountFrom = payCountFrom,
                PayCountTo =  payCountTo,
                PercentFrom = percentFrom,
                PercentTo = percentTo,
                SearchResult = true
            };

            return viewModel;
        }
    }
}