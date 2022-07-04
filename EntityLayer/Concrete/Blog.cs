using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog:IEntity
    {
        [Key]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public int Comment { get; set; }
        public int ReadCount { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        public int Id { get; set; }
        public int CategoryID { get; set; }

    }
}
