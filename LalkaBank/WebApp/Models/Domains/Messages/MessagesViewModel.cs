using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models.Domains.Messages
{
    public class MessagesViewModel
    {
        public MessagesViewModel()
        {
            Page = 1;
        }
        public IEnumerable<MessageViewModel> Messages { get; set; }

        public int Page { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}