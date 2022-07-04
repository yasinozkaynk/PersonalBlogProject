using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.Writer.ViewComponents
{
    public class TopRatedBlog:ViewComponent
    {
        IBlogService _blogService;
        private readonly UserManager<WriterUser> _userManager;

        public TopRatedBlog(UserManager<WriterUser> userManager, IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = values.Id;
            var result = _blogService.GetByUserId(userId);
            return View(result);
        }
    }
}
