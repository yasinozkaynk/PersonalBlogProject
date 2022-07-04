using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Models
{
    public class BlogModel
    {
        public List<Blog> Blogs { get; set; }
        public List<BlogDto> BlogDtos { get; set; }
        public BlogDto BlogDto { get; set; }
        public Blog Blog { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
    }
}
