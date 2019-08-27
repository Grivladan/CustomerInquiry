using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerInquiry.Dal
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}