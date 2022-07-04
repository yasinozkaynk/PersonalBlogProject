using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GetBlogDto:IEntity
    {
        public int BlogID { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int ReadCount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string CommentContent { get; set; }
        public string CommentSubject { get; set; }
    }
}
