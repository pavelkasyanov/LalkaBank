using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using DAO.Interafaces;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using WebApp.Models.Domains.Credits;
using WebApp.Models.Domains.Requests;
using WebApp.Models.Domains.Users;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [Authorize]
    public class CreditsController : Controller
    {
        private readonly ICreditService _creditService;
        private readonly ICreditHistoryService _creditHistorySevice;

        public CreditsController(ICreditService creditService, 
            ICreditHistoryService creditHistorySevice)
        {
            _creditService = creditService;
            _creditHistorySevice = creditHistorySevice;
        }

        // GET: Credits
        public ActionResult Index(CreditsViewModel model)
        {
            //var viewModel = GetCreditsViewModel(model.CurrentPageNumber);

            //return View(viewModel);
            return RedirectToAction("Actives");
        }

        public ActionResult Actives(CreditsViewModel model)
        {
            var viewModel = GetCreditsViewModel(model.CurrentPageNumber, 
                "Actives");

            return View("Index", viewModel);
        }

        public ActionResult Closeds(CreditsViewModel model)
        {
            var viewModel = GetCreditsViewModel(model.CurrentPageNumber, 
                "Closeds");

            return View("Index", viewModel);
        }

        public ActionResult Overdues(CreditsViewModel model)
        {
            var viewModel = GetCreditsViewModel(model.CurrentPageNumber,
                "Overdues");

            return View("Index", viewModel);
        }

        public ActionResult Show(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpNotFoundResult();
            }
            var viewModel = GetCreditViewModel(id.Value);

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Result = true;
            }

            return View(viewModel);
        }

        public ActionResult ShowCreditHistory(CreditHistoryViewModel model)
        {
            if (Guid.Empty.Equals(model.CreditId))
            {
                return HttpNotFound();
            }

            var viewModel = GetCreditHistoryViewModel(model.CreditId, model.CurrentPageNumber);

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(Guid requestId)
        {
            var result = _creditService.CreateCreditForRequest(requestId);
            if (result != null)
            {
                ViewBag.Result = true;
                ViewBag.ResultMsg = "credit created";

                return RedirectToAction("Show", new {id = result.Value});
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "credit not created";
            }
            return RedirectToAction("Show");
        }

        public ActionResult Search()
        {
            return View();
        }

        //Ajax
        [AjaxActionFilter]
        public ActionResult GetActivesCreditCount()
        {
            var list = User.IsInRole("User") ?
                _creditService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _creditService.GetList();

            var t = list.Count(x => x.Status.Equals("0"));

            return Json(new {result = t }, JsonRequestBehavior.AllowGet);
        }

        [AjaxActionFilter]
        public ActionResult GetOverduesCreditCount()
        {
            var list = User.IsInRole("User") ?
                _creditService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _creditService.GetList();
            
            var t = list.Count(x => x.CreditHistory.Sum(y => y.Arrears) > 0);

            return Json(new { result = t }, JsonRequestBehavior.AllowGet);
        }

        private CreditsViewModel GetCreditsViewModel(int pageNumber, 
            String action)
        {
            int itemsInPage = 10;

            List<Credit> list = null;
            list = User.IsInRole("User") ?
                _creditService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _creditService.GetList();

            switch (action)
            {
                case "Actives":
                    list = list.Where(x => x.Status.Equals("0")).ToList();
                    break;
                case "Closeds":
                    list = list.Where(x => x.Status.Equals("1")).ToList();
                    break;
                case "Overdues":
                    //list = list.Where(x => x.Status.Equals("0") && x.DateEnd <= _creditService.GetTimeTable().Date).ToList();
                    list = list.Where(x => x.CreditHistory.Sum(y => y.Arrears) > 0).ToList();
                    break;
                default:
                    break;
            }

            if (list == null || list.Count == 0)
            {
                return new CreditsViewModel()
                {
                    IsSearch = false
                };
            }

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count / itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ((pageNumber >= allPageCount && ost != 0) ? ost : itemsInPage);

            if (list.Count != 0)
            {
                list = list.OrderBy(x => x.Number).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var model = new CreditsViewModel()
            {
                Credits = list.Select(
                credit => new CreditViewModel()
                {
                    Id = credit.Id,
                    DateStart = credit.DateStart,
                    DateEnd = credit.DateEnd,
                    Percent = credit.Percent,
                    StartSum = credit.StartSum,
                    AllSum = credit.AllSum,
                    PayCount = credit.PayCount,
                    Status = credit.Status,
                    Penya = credit.Penya,
                    PayMounth = credit.PayMounth,
                    Number = credit.Number
                }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                IsSearch = true,
                Action = action
            };

            return model;
        }

        private CreditsViewModel GetEmptyCreditsViewModel()
        {
            var viewModel = new CreditsViewModel()
            {
                Credits = new List<CreditViewModel>()
            };

            return viewModel;
        }

        private CreditViewModel GetCreditViewModel(Guid creditId)
        {
            var credit = _creditService.Get(creditId);
            if (credit == null)
            {
                return null;
            }

            var viewModel = new CreditViewModel()
            {
                Id = credit.Id,
                DateStart =  credit.DateStart,
                DateEnd = credit.DateEnd,
                Percent = credit.Percent,
                PayCount = credit.PayCount,
                PayMounth = credit.PayMounth,
                Penya = credit.Penya,
                StartSum = credit.StartSum,
                Status = credit.Status,
                Number = credit.Number,
                Person = new UserInfoViewModel()
                {
                    Id = credit.Persons.Id,
                    Name = credit.Persons.Name,
                    Email = credit.Persons.Login,
                    LastName = credit.Persons.LastName,
                    SecondName = credit.Persons.SecondName
                }
            };

            decimal dept = credit.CreditHistory.Sum(creditHistoryItem => creditHistoryItem.Arrears);
            dept += credit.CreditHistory.Sum(creditHistoryItem => creditHistoryItem.Fine);
            dept = (int)Math.Ceiling(dept);

            viewModel.CurrentDept = dept;
            viewModel.AllSum = credit.CreditHistory.Sum(x => x.TotalPayment);

            return viewModel;
        }

        private CreditViewModel GetEmptyCreditViewModel()
        {

            var viewModel = new CreditViewModel();
            
            return viewModel;
        }

        private CreditHistoryViewModel GetCreditHistoryViewModel(Guid creditId, int pageNumber)
        {
            int itemsInPage = 10;

            List<CreditHistory> list = null;
            list = _creditHistorySevice.GetListFromCredit(creditId);
            if (list == null)
            {
                return new CreditHistoryViewModel()
                {
                    IsSearch = false
                };
            }

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count / itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ((pageNumber >= allPageCount && ost != 0) ? ost : itemsInPage);

            if (list.Count != 0)
            {
                list = list.OrderBy(x => x.Month).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var model = new CreditHistoryViewModel()
            {
                CreditHistories = list.Select(
                    creditHistory => new CreditHistoryItemViewModel()
                    {
                        Id = creditHistory.Id,
                        Arrears = creditHistory.Arrears,
                        CreditBalance = creditHistory.CreditBalance,
                        Percent = creditHistory.Percent,
                        CreditId = creditHistory.CreditId,
                        Month = creditHistory.Month,
                        Fine = creditHistory.Fine,
                        FinePayment = creditHistory.FinePayment,
                        MainPayment = creditHistory.MainPayment,
                        Paid = creditHistory.Paid,
                        TotalPayment = creditHistory.TotalPayment
                    }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                IsSearch = true,
                CreditId = creditId
            };

            return model;
        }
    }
}