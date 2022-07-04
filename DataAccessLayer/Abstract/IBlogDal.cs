using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal:IEntityRepository<Blog>
    {
        List<BlogDto> Blogs(Expression<Func<BlogDto, bool>> filter = null);
        List<BlogDto> LastBlog(Expression<Func<BlogDto, bool>> filter = null);
        List<BlogDto> TopBlog(Expression<Func<BlogDto, bool>> filter = null);
        BlogDto GetByBlogID(Expression<Func<BlogDto, bool>> filter);

    }
}
