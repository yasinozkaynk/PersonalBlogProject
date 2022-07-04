using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, Context>, IBlogDal
    {
        public List<BlogDto> Blogs(Expression<Func<BlogDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from p in context.Blogs
                             join c in context.WriterUsers
                             on p.Id equals c.Id
                             orderby p.ReadCount descending
                             select new BlogDto
                             {
                                 BlogID = p.BlogID,
                                 Comment = p.Comment,
                                 DateAdded = p.DateAdded,
                                 Title = p.Title,
                                 Content = p.Content,
                                 ReadCount = p.ReadCount,
                                 ImageUrl = p.ImageUrl,
                                 WriterName = c.Name,
                                 UserImageUrl = c.ImageUrl,
                                 WriterSurname = c.Surname,
                                 DateOfAdded = p.DateOfUpdate,
                                 Status=p.Status,
                                 Id = p.Id,
                                 CategoryID=p.CategoryID
                                
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }

        public List<BlogDto> LastBlog(Expression<Func<BlogDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result =  from  p in context.Blogs 
                              orderby p.DateAdded descending
                              select new BlogDto
                             {
                                 BlogID = p.BlogID,
                                 DateAdded = p.DateAdded,
                                 Title = p.Title,
                                 ImageUrl = p.ImageUrl,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<BlogDto> TopBlog(Expression<Func<BlogDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from p in context.Blogs
                             orderby p.DateAdded descending
                             orderby p.ReadCount descending
                             select new BlogDto
                             {
                                 BlogID = p.BlogID,
                                 DateAdded = p.DateAdded,
                                 Title = p.Title,
                                 ImageUrl = p.ImageUrl,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<BlogDto> GetByBlog(Expression<Func<BlogDto, bool>> filter)
        {
            using (Context context = new Context())
            {
                var result = from p in context.Blogs
                             orderby p.DateAdded descending
                             orderby p.ReadCount descending
                             select new BlogDto
                             {
                                 BlogID = p.BlogID,
                                 DateAdded = p.DateAdded,
                                 Title = p.Title,
                                 ImageUrl = p.ImageUrl,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public BlogDto GetByBlogID(Expression<Func<BlogDto, bool>> filter)
        {
            using (Context context = new Context())
            {
                var result = from p in context.Blogs
                             join c in context.WriterUsers
                             on p.Id equals c.Id
                             orderby p.ReadCount descending
                             select new BlogDto
                             {
                                 BlogID = p.BlogID,
                                 Comment = p.Comment,
                                 DateAdded = p.DateAdded,
                                 Title = p.Title,
                                 Content = p.Content,
                                 ReadCount = p.ReadCount,
                                 ImageUrl = p.ImageUrl,
                                 WriterName = c.Name,
                                 UserImageUrl = c.ImageUrl,
                                 WriterSurname = c.Surname,
                                 DateOfAdded = p.DateOfUpdate,
                                 Status = p.Status,
                                 Id = p.Id
                             };
                return result.SingleOrDefault(filter);

            }

        }

       
    }
}

