using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.ViewComponents
{
    public class TopBlog:ViewComponent
    {
        IBlogService _blogService;
        public TopBlog( IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _blogService.TopBlog();
            return View(result);
        }
    }
}
