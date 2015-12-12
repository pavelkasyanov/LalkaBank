using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPersonService _personService;

        public AdminController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BanUser(Guid userId, bool isBan)
        {
            var bannedUser = _personService.Get(userId);
            if (bannedUser == null)
            {
                return Json(new {result = false, msg = "user not exist", banned = false}, JsonRequestBehavior.AllowGet);
            }

            bannedUser.IsBanned = isBan;

            if (_personService.Create(bannedUser))
            {
                return Json(new { result = true,
                    msg = isBan  ? "user account baned" : "user account unbaned", banned = isBan}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, msg = "user not baned(unknown error)", bannedUser = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}