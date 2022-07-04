using Business.Abstract;
using PersonalBlog_Proje.Areas.WriterBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var result = new BlogModel
            {
                Categories = _categoryService.TGetList()
            };
            return View(result);
        }
    }
}
