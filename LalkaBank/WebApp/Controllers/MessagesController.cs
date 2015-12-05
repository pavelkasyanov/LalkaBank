using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using WebApp.Models.Domains.Messages;
using WebApp.Models.Domains.Users;

namespace WebApp.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            this._messageService = messageService;
        }

        // GET: Messages
        public ActionResult Index()
        {
            var messages = _messageService.GetFromUser( Guid.Parse(User.Identity.GetUserId()) );
            var viewModel = new MessagesViewModel()
            {
                Messages = messages.Select(msg => new MessageViewModel()
                {
                     Id = msg.Id,
                     Text = msg.Text,
                     UserInfo = new UserInfoPartialViewModel()
                     {
                         Name = msg.Persons.Name
                     }
                }).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Show(Guid id)
        {
            var viewModel = GetMessageViewModel(id);
            return View(viewModel);
        }

        public MessageViewModel GetMessageViewModel(Guid id)
        {
            var viewModel = new MessageViewModel();
            return viewModel;
        }
    }
}