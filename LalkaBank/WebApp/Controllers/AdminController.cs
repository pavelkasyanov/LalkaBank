using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;
using WebApp.Models.Domains.Admins;
using WebApp.Models.Domains.Managers;
using WebApp.Models.Domains.Users;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IManagerService _managerService;

        public AdminController(IPersonService personService, IManagerService managerService)
        {
            _personService = personService;
            _managerService = managerService;
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

        public ActionResult UsersList(UsersListViewModel model)
        {
            var viewModel = this.GetUsersListViewModel(model.CurrentPageNumber,
                model.SearchLogin, model.SearchName, model.SearchSurname);

            return View(viewModel);
        }

        public ActionResult ManagersList(ManagersListViewModel model)
        {
            var viewModel = this.GetManagersListViewModel(model.CurrentPageNumber,
                model.SearchLogin, model.SearchName, model.SearchPosition);

            return View(viewModel);
        }

        private UsersListViewModel GetUsersListViewModel(int pageNumber,
            string searchLogin, string searchName, string searchSurname)
        {
            int itemsInPage = 10;

            var list = _personService.GetList();

            {
                if (!string.IsNullOrEmpty(searchLogin))
                {
                    list = list.Where(x => x.Login.Contains(searchLogin)).ToList();
                }

                if (!string.IsNullOrEmpty(searchName))
                {
                    list = list.Where(x => x.Name.Contains(searchName)).ToList();
                }

                if (!string.IsNullOrEmpty(searchSurname))
                {
                    list = list.Where(x => x.SecondName.Contains(searchSurname)).ToList();
                }
            }

            if (list.Count == 0)
            {
                return new UsersListViewModel()
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
                list = list.OrderBy(x => x.Login).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var viewModel = new UsersListViewModel()
            {
                Users = list.Select(
                    user => new UserInfoViewModel()
                    {
                        Id = user.Id,
                        Email = user.Login,
                        Name = user.Name,
                        SecondName = user.SecondName,
                        LastName = user.LastName,
                        IsBanned =  user.IsBanned
                    }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                SearchLogin = searchLogin,
                SearchName = searchName,
                SearchSurname = searchSurname,
                SearchResult = true
            };

            return viewModel;
        }

        private ManagersListViewModel GetManagersListViewModel(int pageNumber,
            string searchLogin, string searchName, string searchPosititon)
        {
            int itemsInPage = 10;

            var list = _managerService.GetList();

            {
                if (!string.IsNullOrEmpty(searchLogin))
                {
                    list = list.Where(x => x.Login.Contains(searchLogin)).ToList();
                }

                if (!string.IsNullOrEmpty(searchName))
                {
                    list = list.Where(x => x.Name.Contains(searchName)).ToList();
                }

                if (!string.IsNullOrEmpty(searchPosititon))
                {
                    list = list.Where(x => x.Position.Contains(searchPosititon)).ToList();
                }
            }

            if (list.Count == 0)
            {
                return new ManagersListViewModel()
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
                list = list.OrderBy(x => x.Login).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var viewModel = new ManagersListViewModel()
            {
                Managers = list.Select(
                    manager => new ManagerViewModel()
                    {
                        Id = manager.Id,
                        Name = manager.Name,
                        Position = manager.Position
                    }).ToList(),

                CurrentPageNumber = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage,
                SearchLogin = searchLogin,
                SearchName = searchName,
                SearchPosition = searchPosititon,
                SearchResult = true
            };

            return viewModel;
        }
    }
}