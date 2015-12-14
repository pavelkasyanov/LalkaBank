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
        [DisplayName("DateEnd")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("DateEnd")]
        public DateTime DateEnd { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Percent")]
        public double Percent { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("StartSum")]
        public int StartSum { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("AllSum")]
        public int AllSum { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PayCount")]
        public int PayCount { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Status")]
        public string Status { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Penya")]
        public double Penya { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PayMounth")]
        public int PayMounth { get; set; }

        public virtual UserInfoViewModel Person { get; set; }

        public virtual ManagerViewModel Manager { get; set; }

        public virtual CreditTypeViewModel CreditType { get; set; }

    }
}