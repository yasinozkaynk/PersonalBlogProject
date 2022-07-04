using Business.Abstract;
using PersonalBlog_Proje.Areas.Writer.Models;
using PersonalBlog_Proje.Areas.WriterBlog.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Blog/")]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        private readonly UserManager<WriterUser> _userManager;
        public BlogController(IBlogService blogService, UserManager<WriterUser> userManager)
        {
            _blogService = blogService;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = values.Id;
            var result = _blogService.GetByUserId(userId);
            return View(result);
        }

        [HttpGet]
        [Route("InsertBlog")]
        public async Task<IActionResult> InsertBlog()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            BlogInsertViewModel model = new BlogInsertViewModel();
            model.Id = values.Id;
            return View(model);
        }

        [HttpPost]
        [Route("InsertBlog")]
        public async Task<IActionResult> InsertBlog(Blog blog)
        {
            _blogService.TAdd(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditBlog/{BlogId}")]
        public async Task<IActionResult> EditBlog(int BlogId)
        {
            var result = _blogService.TGetByID(BlogId);
            return View(result);
        }

        [HttpPost]
        [Route("EditBlog/{BlogId}")]
        public async Task<IActionResult> EditBlog(Blog blog)
        {
            _blogService.TUpdate(blog);
            return RedirectToAction("Index");
        }
    }
}
