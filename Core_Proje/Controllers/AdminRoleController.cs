using PersonalBlog_Proje.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Controllers
{
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<WriterRole> _roleManager;
        private readonly UserManager<WriterUser> _userManager;

        public AdminRoleController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserRoleList()
        {
            var result = _userManager.Users.ToList();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssign = new RoleAssignViewModel();
                roleAssign.RoleID = item.Id;
                roleAssign.Name = item.Name;
                roleAssign.Exists = userRoles.Contains(item.Name);
                model.Add(roleAssign);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in models)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user,item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
