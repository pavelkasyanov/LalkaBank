using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Requests
{
    public class FindRequestsViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        public int Page { get; set; }
    }
}