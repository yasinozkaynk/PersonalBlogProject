﻿using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.ViewComponents.Admin
{
    public class AdminSideBar:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminSideBar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;
            ViewBag.v1 = values.ImageUrl;
            return View();
        }
    }
}
