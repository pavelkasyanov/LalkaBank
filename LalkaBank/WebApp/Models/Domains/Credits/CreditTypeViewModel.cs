﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Credits
{
    public class CreditTypeViewModel
    {
        public System.Guid Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Percent")]
        public double Percent { get; set; }

        [Required]
        [DisplayName("StartSumPercent")]
        public double StartSumPercent { get; set; }

        [Required]
        [DisplayName("PayCount")]
        public int PayCount { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Размер кредита")]
        public string Info { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("SubType")]
        public Guid SubTypeId { get; set; }

        public virtual IEnumerable<SelectListItem> SubTypes { get; set; }
    }
}