using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using WebApp.Models.Domains.Users;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {
            var role = User.IsInRole("User");
            if (role)
            {
                return RedirectToAction("UserInfo", "User");
            }
            else 
            {
                if (User.IsInRole("Manager"))
                    return RedirectToAction("Index", "Managers");
            }

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        private UserInfoViewModel GetUserInfoViewModel(Guid userId)
        {
            var user = _personService.Get(userId);
            if (user == null)
            {
                return null;
            }

            var viewModel = new UserInfoViewModel()
            {
                Email = user.Login,
                Name = user.Name,
                SecondName = user.SecondName,
                LastName = user.LastName,
                DateBirth = user.DateBirth.Value,
                Number = user.Passports.Number,
                RUVD = user.Passports.RUVD,
                Adress = user.Passports.Adress,
                Validity = user.Passports.Validity,
                CreditHistoryIndex = user.CreditHistoryIndex,
                PassportImage = user.Passports.Image
            };

            return viewModel;
        }
    }
}