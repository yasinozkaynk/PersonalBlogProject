using Business.Abstract;
using PersonalBlog_Proje.Areas.WriterBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.Controllers
{
    [Area("WriterBlog")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index(int page=1,int userId=0)
        {
            int pageSize = 6;
            var blogs = _blogService.GetByUserId(userId);
            var result = new BlogModel
            {
                BlogDtos = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(blogs.Count / (double)pageSize),
                PageSize = pageSize,
            };
            return View(result);
        }

        [HttpGet]
        public IActionResult BlogDetails(int id)
        {
            var result = _blogService.IncreaseReadCount(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult BlogList(int id)
        {
            var result = new BlogModel
            {
                BlogDtos = _blogService.GetByCategory(id)
            };
            return View(result);
        }


    }
}
