using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using WebApp.Models.Validators;

namespace WebApp.Models.Domains.Users
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "SecondName")]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [BirthDateValidator]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy'-'MM'-'dd}", ApplyFormatInEditMode = true)]
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

        [PassportDateValidator]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия до")]
        [DisplayFormat(DataFormatString = "{0:yyyy'-'MM'-'dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Validity { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Кредитная история")]
        public int CreditHistoryIndex { get; set; }

        [DisplayName("PassportImage")]
        public byte[] PassportImage { get; set; }

        [DisplayName("IncomeImage")]
        public HttpPostedFileBase PassportImg { get; set; }

        public bool IsBanned { get; set; }

        public Guid PassportId { get; set; }

        public bool IsUserRegister { get; set; }

        [DisplayName("ScoringSystemIndex")]
        public int ScoringSystemIndex { get; set; }
    }
}