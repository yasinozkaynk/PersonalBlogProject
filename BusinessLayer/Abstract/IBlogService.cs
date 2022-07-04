using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<BlogDto> Blogs();
        List<Blog> GetByBlogCommentID(int id);
        Blog IncreaseReadCount(int id);
        List<BlogDto> GetByUserId(int id);
        Blog GetByBlog(int id);
        BlogDto GetByBlogID(int id);
        List<BlogDto> ThreeTopRated();
        List<BlogDto> TopBlog();
        List<BlogDto> GetByCategory(int id);

    }
}
