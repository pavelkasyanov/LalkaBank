using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Domains.Users
{
    public class UserInfoViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Номер паспорта")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Text)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Кем выдан")]
        public string RUVD { get; set; }

        [Required]
        [DataType(DataType.Text)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Место прописки")]
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия до")]
        public System.DateTime Validity { get; set; }
    }
}