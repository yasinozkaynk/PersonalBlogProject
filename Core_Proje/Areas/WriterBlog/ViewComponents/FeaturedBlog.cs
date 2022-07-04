using Business.Abstract;
using PersonalBlog_Proje.Areas.WriterBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.ViewComponents
{
    public class FeaturedBlog:ViewComponent
    {
        IBlogService _blogService;

        public FeaturedBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.TopBlog();
            return View(result);
        }
    }
}
