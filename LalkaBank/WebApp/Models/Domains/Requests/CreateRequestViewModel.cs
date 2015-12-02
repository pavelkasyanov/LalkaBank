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
        [DisplayName("Тип кредита")]
        public Guid CreditTypeId { get; set; }
        public IEnumerable<SelectListItem> CreditTypes { get; set; }

        [DisplayName("Размер кредита")]
        [Required]
        public short StartSum { get; set; }

        [DisplayName("Дополнительная информация")]
        public string CreditInfo { get; set; }
    }
}