using Business.Abstract;
using PersonalBlog_Proje.Areas.WriterBlog.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.ViewComponents
{
    public class WriterList:ViewComponent
    {
        IBlogService _blogService;
        IWriterUserService _writerUserService;
        public WriterList(IBlogService blogService, IWriterUserService writerUserService)
        {
            _blogService = blogService;
            _writerUserService = writerUserService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _writerUserService.TGetList();
            return View(result);
        }
    
        
    }
}
