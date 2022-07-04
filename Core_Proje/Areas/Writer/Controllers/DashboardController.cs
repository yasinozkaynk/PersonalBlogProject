using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalBlog_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        IBlogService _blogService;

        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager, IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;
            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            var userId = values.Id;
            ViewBag.v6 = _blogService.GetByUserId(userId).Count();
            return View();
        }
    }
}
