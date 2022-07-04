using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
   public class Message : IEntity
    {
        [Key]
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
