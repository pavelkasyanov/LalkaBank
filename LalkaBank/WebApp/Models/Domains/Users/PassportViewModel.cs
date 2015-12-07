using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Users
{
    public class PassportViewModel
    {
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