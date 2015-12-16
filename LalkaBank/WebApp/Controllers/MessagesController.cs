using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using WebApp.Models.Domains.Messages;
using WebApp.Models.Domains.Requests;
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
        public ActionResult Index(MessagesViewModel model)
        {

            var viewModel = GetMessagesViewModelFromPage(model.Page);

            return View(viewModel);
        }

        public ActionResult Show(Guid? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var viewModel = GetMessageViewModel(id.Value);
            return PartialView(viewModel);
        }

        public MessageViewModel GetMessageViewModel(Guid id)
        {
            var message = _messageService.Get(id);
            if (message == null)
            {
                return null;
            }

            var viewModel = new MessageViewModel()
            {
                Id = message.Id,
                Text = message.Text,
                UserInfo = new UserInfoPartialViewModel()
                {
                    Email = message.Persons.Login,
                    Name = message.Persons.Name,
                    SecondName = message.Persons.SecondName,
                    LastName = message.Persons.LastName,
                    CreditHistoryIndex = message.Persons.CreditHistoryIndex,
                    DateBirth = message.Persons.DateBirth.Value
                },

                Request = new RequestViewModel()
                {
                    Id = message.Request.Id,
                    CreditInfo = message.Request.CreditInfo,
                    Confirm = message.Request.Confirm,
                    Date = message.Request.Date,
                    Number = message.Request.Number,
                    CreditId = message.Request.CreditId.GetValueOrDefault()
                }
            };
            return viewModel;
        }

        private MessagesViewModel GetMessagesViewModelFromPage(int pageNumber)
        {
            int itemsInPage = 10;

            List<Message> list = null;
            list = User.IsInRole("User") ?
                _messageService.GetFromUser(Guid.Parse(User.Identity.GetUserId())) : _messageService.GetFromManager(Guid.Parse(User.Identity.GetUserId()));
            if (list == null)
            {
                return null;
            }

            int startRange = pageNumber * 10 - itemsInPage;
            int allPageCount = list.Count / itemsInPage;
            int ost = list.Count % itemsInPage;
            if (ost != 0) { allPageCount++; }

            int selectCount = ((pageNumber >= allPageCount && ost != 0) ? ost : itemsInPage);

            if (list.Count != 0)
            {
                //list = list.OrderBy(x => x.).ToList();
                list = list.GetRange(startRange, selectCount);
            }

            var model = new MessagesViewModel()
            {
                Messages = list.Select(msg => new MessageViewModel()
                {
                    Id = msg.Id,
                    Text = msg.Text,
                    UserInfo = new UserInfoPartialViewModel()
                    {
                        Name = msg.Persons.Name
                    }
                }).ToList(),

                Page = pageNumber,
                AllPageCount = allPageCount,
                ItemsPerPage = itemsInPage
            };

            return model;
        }
    }
}