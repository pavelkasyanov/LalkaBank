using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Domains.Managers;

namespace WebApp.Models.Domains.Admins
{
    public class ManagersListViewModel
    {
        public ManagersListViewModel()
        {
            CurrentPageNumber = 1;
        }

        public IEnumerable<ManagerViewModel> Managers { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchLogin { get; set; }

        public string SearchName { get; set; }

        public string SearchPosition { get; set; }

        public bool SearchResult { get; set; }
    }
}