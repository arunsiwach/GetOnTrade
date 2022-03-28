using GetOnTrades.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOnTrades.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository messageRepository;
        /// <summary>
        /// This is messages
        /// </summary>
        /// <param name="messageRepository"></param>
        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public ViewResult ShowMessages()
        {
            //ViewBag.Messages = messageRepository.AllMessagesString;
            return View(messageRepository.AllMessages);
            
        }
    }
}
