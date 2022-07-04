using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<BlogDto> Blogs()
        {
            return _blogDal.Blogs();
        }

        public Blog GetByBlog(int id)
        {
            return _blogDal.GetByID(x=>x.BlogID==id);
        }

        public List<Blog> GetByBlogCommentID(int id)
        {
            return _blogDal.GetList(x=>x.BlogID==id);
        }

        public BlogDto GetByBlogID(int id)
        {
            return _blogDal.GetByBlogID(x => x.BlogID == id);
        }

        public List<BlogDto> GetByCategory(int id)
        {
            return _blogDal.Blogs(x=>x.CategoryID==id);
        }

        public List<BlogDto> GetByUserId(int userId)
        {
            return _blogDal.Blogs(x => x.Id == userId || userId==0);
        }

        public Blog IncreaseReadCount(int id)
        {
            var result = _blogDal.GetByID(x => x.BlogID == id);
            result.ReadCount++;
            _blogDal.Update(result);
            return result;       
        }

        public void TAdd(Blog t)
        {
            t.DateAdded = DateTime.Now;
            t.DateOfUpdate = DateTime.Now;
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public Blog TGetByID(int id)
        {
           return _blogDal.GetByID(x=>x.BlogID==id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetList();
        }

        public List<Blog> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public List<BlogDto> ThreeTopRated()
        {
            return _blogDal.LastBlog().Take(3).ToList();
        }

        public List<BlogDto> TopBlog()
        {
            return _blogDal.TopBlog().Take(2).ToList();
        }

        public void TUpdate(Blog t)
        {
            t.DateAdded = DateTime.Now;
            t.DateOfUpdate = DateTime.Now;
            _blogDal.Update(t);
        }
    }
}
