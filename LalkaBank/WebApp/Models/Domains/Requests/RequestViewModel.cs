using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Domains.Credits;
using WebApp.Models.Domains.Users;

namespace WebApp.Models.Domains.Requests
{
    public class RequestViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Credit Info")]
        public string CreditInfo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Date")]
        public System.DateTime Date { get; set; }

        [DisplayName("Request Number")]
        public int Number { get; set; }

        [DisplayName("User Passport Image")]
        public byte[] PassportImage { get; set; }

        [DisplayName("User Income Image")]
        public byte[] IncomeImage { get; set; }

        [DisplayName("Request Status")]
        public int Confirm { get; set; }

        public Guid CreditId { get; set; }

        [DisplayName("Credit Type")]
        public virtual CreditTypeViewModel CreditType { get; set; }

        [DisplayName("User Information")]
        public virtual UserInfoPartialViewModel UserInfo { get; set; }

        [DisplayName("Passport")]
        public virtual PassportViewModel PersonPassport { get; set; }

    }
}