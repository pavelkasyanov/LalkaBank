using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using WebApp.Models.Domains.Managers;
using WebApp.Models.Domains.Users;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ManagersController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET: Managers
        public ActionResult Index(Guid? id, string returnUrl)
        {
            
            var userId = id ?? Guid.Parse(User.Identity.GetUserId());
            var user = _managerService.Get(userId);

            var model = new ManagerViewModel()
            {
                Login = user?.Login ?? User.Identity.Name,
                Name = user?.Name ?? "",
                Position = user?.Position ?? "1",
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var user = _managerService.Get(userId);

            var model = new ManagerViewModel()
            {
                Login = user?.Login ?? User.Identity.Name,
                Name = user?.Name ?? "",
                Position = user ?.Position ?? "1"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ManagerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var manager = new Manager()
            {
                Id = Guid.Parse(User.Identity.GetUserId()),
                Login = viewModel.Login,
                Name = viewModel.Name,
                Position = viewModel.Position
            };

            var result = _managerService.Create(manager);
            if (result)
            {
                ViewBag.Result = true;
                ViewBag.ResultMsg = "suc";
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.ResultMsg = "error update your info";
            }

            return View(viewModel);
        }
    }
}