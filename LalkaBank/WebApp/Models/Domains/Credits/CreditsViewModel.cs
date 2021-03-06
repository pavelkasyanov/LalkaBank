﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Credits
{
    public class CreditsViewModel
    {
        public CreditsViewModel()
        {
            CurrentPageNumber = 1;
            Action = "Index";
        }

        public IEnumerable<CreditViewModel> Credits { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool IsSearch { get; set; }

        public string Action { get; set; }

        public string NotFoundMsg { get; set; }
    }
}