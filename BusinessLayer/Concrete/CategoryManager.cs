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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetByCategory(int id)
        {
            return _categoryDal.GetList(x=>x.CategoryID==id);
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(x=>x.CategoryID==id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public List<Category> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
