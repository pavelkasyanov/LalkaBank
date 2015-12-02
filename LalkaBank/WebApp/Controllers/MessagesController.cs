using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }
    }
}