using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Domains.Credits;
using WebApp.Models.Domains.Users;

namespace WebApp.Models.Domains.Requests
{
    public class RequestViewModel
    {
        public Guid RequestId { get; set; }

        [Required]
        [DisplayName("Размер кредита")]
        public string CreditInfo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("DateStart")]
        public System.DateTime DateStart { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName(" DateEnd")]
        public System.DateTime DateEnd { get; set; }

        [DisplayName(" DateEnd")]
        public int Number { get; set; }

        [DisplayName("PassportImage")]
        public byte[] PassportImage { get; set; }

        [DisplayName("IncomeImage")]
        public byte[] IncomeImage { get; set; }

        [DisplayName("Status")]
        public int Confirm { get; set; }

        [DisplayName("CreditType")]
        public virtual CreditTypeViewModel CreditType { get; set; }

        [DisplayName(" UserInfo")]
        public virtual UserInfoPartialViewModel UserInfo { get; set; }

        [DisplayName("Passport")]
        public virtual PassportViewModel PersonPassport { get; set; }

    }
}