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

            return View(viewModel);
        }
        
        public ActionResult Show(Guid creditId)
        {
            var viewModel = GetCreditViewModel(creditId);

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(Guid requestId)
        {
            _creditService.CreateCreditForRequest(requestId);
            return View("Index");
        }

        private CreditsViewModel GetCreditsViewModel()
        {
            var allCredits = _creditService.GetList();
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

        private CreditViewModel GetCreditViewModel(Guid creditId)
        {
            var credit = _creditService.Get(creditId);
            var viewModel = new CreditViewModel()
            {
                Id = credit.Id
            };

            return viewModel;
        }
    }
}