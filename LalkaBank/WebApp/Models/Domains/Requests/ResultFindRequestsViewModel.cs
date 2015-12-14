using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Requests
{
    public class ResultFindRequestsViewModel
    {
        public ResultFindRequestsViewModel()
        {
            CurrentPageNumber = 1;
            Start = DateTime.Now;
            End = DateTime.Now;
        }

        [DataType(DataType.Date)]
        [Display(Name = "Start")]
        [DisplayFormat(DataFormatString = "{0:yyyy'-'MM'-'dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End")]
        [DisplayFormat(DataFormatString = "{0:yyyy'-'MM'-'dd}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        public IEnumerable<RequestViewModel> Requests { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}