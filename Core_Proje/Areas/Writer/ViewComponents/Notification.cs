using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
