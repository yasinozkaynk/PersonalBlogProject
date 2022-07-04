using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class UserController : Controller
    {
        IWriterUserService _writerUserService;

        public UserController(IWriterUserService writerUserService)
        {
            _writerUserService = writerUserService;
        }

        public IActionResult Index()
        {
            var result = _writerUserService.GetUser();
            return View(result);
        }
    }
}
