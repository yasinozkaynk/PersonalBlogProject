using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v2 = c.Messages.Count();
            return View();
        }
    }
}
