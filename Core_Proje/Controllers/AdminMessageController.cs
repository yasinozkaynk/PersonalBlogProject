using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class AdminMessageController : Controller
    {

        IWriterMessageService _writerMessageService;

        public AdminMessageController(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageService.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageService.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            _writerMessageService.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
