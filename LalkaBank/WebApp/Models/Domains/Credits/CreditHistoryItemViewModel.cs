using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Credits
{
    public class CreditHistoryItemViewModel
    {
        public System.Guid Id { get; set; }

        [DisplayName("Month")]
        public int Month { get; set; }

        [DisplayName("CreditBalance")]
        public decimal CreditBalance { get; set; }

        [DisplayName("MainPayment")]
        public decimal MainPayment { get; set; }

        [DisplayName("Percent")]
        public decimal Percent { get; set; }

        [DisplayName("TotalPayment")]
        public decimal TotalPayment { get; set; }

        [DisplayName("Paid")]
        public decimal Paid { get; set; }

        public System.Guid CreditId { get; set; }

        [DisplayName("Arrears")]
        public decimal Arrears { get; set; }

        [DisplayName("Fine")]
        public decimal Fine { get; set; }

        [DisplayName("FinePayment")]
        public decimal FinePayment { get; set; }
    }
}