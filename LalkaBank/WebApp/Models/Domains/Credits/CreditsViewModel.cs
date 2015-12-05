using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Credits
{
    public class CreditsViewModel
    {
        public IEnumerable<CreditViewModel> Credits { get; set; }
    }
}