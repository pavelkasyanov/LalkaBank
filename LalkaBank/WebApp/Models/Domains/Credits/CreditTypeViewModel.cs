using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Credits
{
    public class CreditTypeViewModel
    {
        public System.Guid CreditTypesId { get; set; }

        [DisplayName("Размер кредита")]
        public double Percent { get; set; }

        [DisplayName("Размер кредита")]
        public double StartSumPercent { get; set; }

        [DisplayName("Размер кредита")]
        public int PayCount { get; set; }


        [DisplayName("Размер кредита")]
        public string Info { get; set; }
    }
}