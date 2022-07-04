using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
   public class SocialMedia : IEntity
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
    }
}
