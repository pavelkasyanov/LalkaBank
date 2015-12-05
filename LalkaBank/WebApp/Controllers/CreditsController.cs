using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class CreditsController : Controller
    {
        // GET: Credits
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create(Guid requestId)
        {
            return View("Index");
        }
    }
}