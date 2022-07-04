using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IBlogService _blogService;

        public CategoryController(ICategoryService categoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.TGetList();
            return View(result);
        }

        public IActionResult GetByBlogs(int id)
        {
            var result = _blogService.GetByCategory(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.TAdd(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _categoryService.TGetByID(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _categoryService.TGetByID(id);
            _categoryService.TDelete(result);
            return RedirectToAction("Index");
        }
    }
}
