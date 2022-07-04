using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T GetByID(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
