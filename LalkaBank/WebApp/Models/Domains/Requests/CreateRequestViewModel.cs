using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Requests
{
    public class CreateRequestViewModel
    {
        [DisplayName("Credit type")]
        public Guid CreditTypeId { get; set; }
        public IEnumerable<SelectListItem> CreditTypes { get; set; }

        [DisplayName("Размер кредита")]
        [Range(1, 500000000, ErrorMessage = "Credit sum is ivalid")]
        public int StartSum { get; set; }

        [DisplayName("Income Image")]
        public HttpPostedFileBase IncomeImage { get; set; }

        [Required]
        [DisplayName("Credit goal")]
        public string CreditInfo { get; set; }

        [Required]
        [DisplayName("Family status")]
        public int FamilyStatus { get; set; }

        public List<SelectListItem> FamilyStatusList { get; set; }

        public int Age { get; set; }

        [Required]
        [DisplayName("Have children?")]
        public bool HaveChildren { get; set; }

        [Required]
        [DisplayName("Education")]
        public int Education { get; set; }

        public List<SelectListItem> EducationList { get; set; }

        [Required]
        [DisplayName("have you a vehicle")]
        public bool HaveVehicle { get; set; }

        [Required]
        [DisplayName("Work experience")]
        [Range(0, 500000000, ErrorMessage = "work experience is ivalid")]
        public int WorkExperience { get; set; }

        [Required]
        [DisplayName("have many times have you changed work for the last 5 years?")]
        public int WorkChangeCount { get; set; }

        public List<SelectListItem> WorkChangeCountList { get; set; }


    }
}