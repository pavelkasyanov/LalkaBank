using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Managers
{
    public class ManagerViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Position")]
        public string Position { get; set; }
    }
}