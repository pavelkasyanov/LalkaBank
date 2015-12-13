using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Domains.Users;

namespace WebApp.Models.Domains.Admins
{
    public class UsersListViewModel
    {
        public UsersListViewModel()
        {
            CurrentPageNumber = 1;
        }

        public IEnumerable<UserInfoViewModel> Users { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchLogin { get; set; }

        public string SearchName { get; set; }

        public string SearchSurname { get; set; }

        public bool SearchResult { get; set; }
    }
}