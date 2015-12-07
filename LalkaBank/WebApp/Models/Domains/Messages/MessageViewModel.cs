using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApp.Models.Domains.Requests;
using WebApp.Models.Domains.Users;

namespace WebApp.Models.Domains.Messages
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Text")]
        public string Text { get; set; }

        public virtual UserInfoPartialViewModel UserInfo { get; set; }

        public virtual RequestViewModel Request { get; set; }

    }
}