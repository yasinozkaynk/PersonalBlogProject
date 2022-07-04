using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogDto: IEntity
    {
        public int BlogID { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Comment { get; set; }
        public int ReadCount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfAdded { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; }
        public string UserImageUrl { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname  { get; set; }
        public int CategoryID  { get; set; }


    }
}
