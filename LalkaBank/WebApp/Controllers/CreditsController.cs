using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;
using WebApp.Models.Domains.Credits;

namespace WebApp.Controllers
{
    [Authorize]
    public class CreditsController : Controller
    {
        private readonly ICreditService _creditService;

        public CreditsController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        // GET: Credits
        public ActionResult Index()
        {
            var viewModel = GetCreditsViewModel();
            if (viewModel == null)
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "error get Credit";
                viewModel = GetEmptyCreditsViewModel();
            }

            return View(viewModel);
        }
        
        public ActionResult Show(Guid creditId)
        {
            var viewModel = GetCreditViewModel(creditId);

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
            return View("Index");
        }

        private CreditsViewModel GetCreditsViewModel()
        {
            var allCredits = _creditService.GetList();
            if (allCredits == null)
            {
                return null;
            }

            var viewModel = new CreditsViewModel()
            {
                Credits = allCredits.Select(credit => new CreditViewModel()
                {
                    Id = credit.Id,
                    DateStart = credit.DateStart,
                    DateEnd = credit.DateEnd
                    
                })
            };

            return viewModel;
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
                Id = credit.Id
            };

            return viewModel;
        }

        private CreditViewModel GetEmptyCreditViewModel()
        {

            var viewModel = new CreditViewModel();
            
            return viewModel;
        }
    }
}