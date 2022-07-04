using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCommentManager : IBlogCommentService
    {
        IBlogCommentDal _blogCommentDal;

        public BlogCommentManager(IBlogCommentDal blogCommentDal)
        {
            _blogCommentDal = blogCommentDal;
        }

        public void TAdd(BlogComment t)
        {
            _blogCommentDal.Insert(t);
        }

        public void TDelete(BlogComment t)
        {
            _blogCommentDal.Delete(t);
        }

        public BlogComment TGetByID(int id)
        {
           return _blogCommentDal.GetByID(x=>x.MessageID==id);
        }

        public List<BlogComment> TGetList()
        {
            return _blogCommentDal.GetList();
        }

        public List<BlogComment> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BlogComment t)
        {
            _blogCommentDal.Update(t);
        }
    }
}
