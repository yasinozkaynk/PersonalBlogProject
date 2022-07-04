using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.ViewComponents
{
    public class ThreeTopRatedBlog : ViewComponent
    {
        IBlogService _blogService;
        public ThreeTopRatedBlog(UserManager<WriterUser> userManager, IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _blogService.ThreeTopRated();
            return View(result);
        }
    }
}
