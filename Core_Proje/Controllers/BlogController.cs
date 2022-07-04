using Business.Abstract;
using PersonalBlog_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var result = new BlogModel
            {
                BlogDtos = _blogService.Blogs()
            };
            return View(result);
        }
        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            var result = new BlogModel
            {
                BlogDto = _blogService.GetByBlogID(id)
            };
            return View(result);
        }

    }
}
