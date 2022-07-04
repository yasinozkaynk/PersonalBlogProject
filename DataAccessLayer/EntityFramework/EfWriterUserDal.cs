using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfWriterUserDal : EfEntityRepositoryBase<WriterUser, Context>, IWriterUserDal
    {
        public List<UserDto> UserDtos()
        {
            using (Context context = new Context())
            {
                var result = from c in context.WriterUsers
                             join p in context.Blogs
                             on c.Id equals p.Id
                             group new { c, p } by new{c.Name , c.Surname ,c.ImageUrl,c.Email,c.Career,c.PhoneNumber,c.Age} into a
                             select new UserDto
                             {
                                 WriterName = a.Key.Name,
                                 BlogCount = a.Count(),
                                 ReadCount = (int)a.Sum(a => a.p.ReadCount),
                                 WriterSurname=a.Key.Surname,
                                 ImageUrl=a.Key.ImageUrl,
                                 Email=a.Key.Email,
                                 Creer=a.Key.Career,
                                 PhoneNumber=a.Key.PhoneNumber,
                                 Age=a.Key.Age,
                             };

                return result.ToList();

            }
        }
    }
}
