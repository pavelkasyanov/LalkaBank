using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Credits
{
    public class SearchCreditsViewModel
    {
        public SearchCreditsViewModel()
        {
            CurrentPageNumber = 1;
        }

        public IEnumerable<CreditViewModel> Credits { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        [DisplayName("search by date")]
        public bool SearchForDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start")]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End")]
        public DateTime End { get; set; }

        [DisplayName("Hide Active")]
        public bool HideActive { get; set; }

        [DisplayName("HideClosed")]
        public bool HideClosed { get; set; }

        [DisplayName("HideOverdues")]
        public bool HideOverdue { get; set; }

        public bool SearchResult { get; set; }

        [DisplayName("User Login")]
        public string UserId { get; set; }

        public virtual IEnumerable<SelectListItem> UserList { get; set; }
    }
}