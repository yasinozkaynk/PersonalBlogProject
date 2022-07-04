using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDto:IEntity
    {
        public int BlogID { get; set; }
        public int Id { get; set; }
        public int ReadCount { get; set; }
        public int BlogCount { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Creer { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
    }
}
