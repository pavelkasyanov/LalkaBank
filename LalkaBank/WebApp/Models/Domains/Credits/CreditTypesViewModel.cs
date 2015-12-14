using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Credits
{
    public class CreditTypesViewModel
    {
        public CreditTypesViewModel()
        {
            CurrentPageNumber = 1;
        }

        public IEnumerable<CreditTypeViewModel> CreditTypes { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Percent")]
        public double PercentFrom { get; set; }

        public double PercentTo { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PayCount")]
        public int PayCountFrom { get; set; }

        public int PayCountTo { get; set; }

        public bool SearchResult { get; set; }

        public bool IsSearch { get; set; }
    }
}