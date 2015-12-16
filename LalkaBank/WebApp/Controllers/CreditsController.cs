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
            var viewModel = GetCreditsViewModel(model.CurrentPageNumber);

            return View(viewModel);
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
                ViewBag.Result = false;
                ViewBag.ResultMsg = "error get Credit";
                viewModel = GetEmptyCreditViewModel();
            }
            else
            {
                ViewBag.Result = true;
            }

            return View(viewModel);
        }

        public ActionResult ShowCreditHistory(CreditHistoryViewModel model)
        {
            var viewModel = GetCreditHistoryViewModel(model.CreditId, model.CurrentPageNumber);

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(Guid requestId)
        {
            var result = _creditService.CreateCreditForRequest(requestId);
            if (result)
            {
                ViewBag.Result = true;
                ViewBag.ResultMsg = "credit created";
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "credit not created";
            }
            return View("Index", GetCreditsViewModel(1));
        }

        public ActionResult Search()
        {
            return View();
        }

        private CreditsViewModel GetCreditsViewModel(int pageNumber)
        {
            int itemsInPage = 10;

            List<Credit> list = null;
            list = User.IsInRole("User") ?
                _creditService.GetListByPersonId(Guid.Parse(User.Identity.GetUserId())) : _creditService.GetList();
            if (list == null)
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
                    PayMounth = credit.PayMounth
                }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                IsSearch = true
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