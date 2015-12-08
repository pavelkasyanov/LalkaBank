using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Requests
{
    public class RequestsViewModel
    {

        public Guid RequestId { get; set; }
        public IEnumerable<SelectListItem> Requests { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}