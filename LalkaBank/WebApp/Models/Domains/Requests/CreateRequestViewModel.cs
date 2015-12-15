using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Requests
{
    public class CreateRequestViewModel
    {
        [DisplayName("Credit type")]
        public Guid CreditTypeId { get; set; }
        public IEnumerable<SelectListItem> CreditTypes { get; set; }

        [DisplayName("Размер кредита")]
        [Range(1, 500000000, ErrorMessage = "Credit sum is ivalid")]
        public int StartSum { get; set; }

        [DisplayName("Income Image")]
        public HttpPostedFileBase IncomeImage { get; set; }

        [DisplayName("Credit goal")]
        public string CreditInfo { get; set; }
    }
}