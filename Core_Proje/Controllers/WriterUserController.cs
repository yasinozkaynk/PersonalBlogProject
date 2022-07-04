using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            //var values = JsonConvert.SerializeObject(userManager.TGetList());
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            //userManager.TAdd(p);
            //var values = JsonConvert.SerializeObject(p);
            return View();
        }
    }
}
