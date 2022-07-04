using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class SocialMediaController : Controller
    {
        ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            var values = _socialMediaService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            _socialMediaService.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia p)
        {
            _socialMediaService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
