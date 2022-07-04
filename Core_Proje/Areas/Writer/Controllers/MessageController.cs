using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message/")]
    public class MessageController : Controller
    {
        IWriterMessageService _writerMessageService;

        public MessageController(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }

        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListSenderMessage(p);
            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var result = _writerMessageService.TGetByID(id);
            return View(result);
        }

        [Route("")]
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            var result = _writerMessageService.TGetByID(id);
            return View(result);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(p);

            return RedirectToAction("SenderMessage");

        }
    }
}