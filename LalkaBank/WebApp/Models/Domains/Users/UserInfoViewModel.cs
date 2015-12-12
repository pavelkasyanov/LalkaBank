using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApp.Models.Domains.Users
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Номер паспорта")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Кем выдан")]
        public string RUVD { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Место прописки")]
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия до")]
        public System.DateTime Validity { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Кредитная история")]
        public int CreditHistoryIndex { get; set; }

        [DisplayName("PassportImage")]
        public byte[] PassportImage { get; set; }

        [DisplayName("IncomeImage")]
        public HttpPostedFileBase PassportImg { get; set; }

        public bool IsBanned { get; set; }
    }
}