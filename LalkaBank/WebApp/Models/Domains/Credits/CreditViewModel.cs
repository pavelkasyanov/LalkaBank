using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Models.Domains.Managers;
using WebApp.Models.Domains.Users;

namespace WebApp.Models.Domains.Credits
{
    public class CreditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start credit date")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("DateEnd")]
        public DateTime DateEnd { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Percent")]
        public double Percent { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Start credit Sum")]
        public int StartSum { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("All credit Sum")]
        public decimal AllSum { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Credit duration(in mounth)")]
        public int PayCount { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Credit status")]
        public string Status { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Penya")]
        public double Penya { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PayMounth")]
        public int PayMounth { get; set; }

        [DisplayName("current credit dept")]
        public decimal CurrentDept { get; set; }

        [DisplayName("Credit number")]
        public int Number { get; set; }

        public string ReturnUrl { get; set; }

        public virtual UserInfoViewModel Person { get; set; }

        public virtual ManagerViewModel Manager { get; set; }

        public virtual CreditTypeViewModel CreditType { get; set; }

    }
}