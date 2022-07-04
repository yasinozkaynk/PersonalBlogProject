using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.Writer.Models
{
    public class BlogInsertViewModel
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public int Comment { get; set; }
        public int ReadCount { get; set; }
        public bool Status { get; set; }
    }
}
