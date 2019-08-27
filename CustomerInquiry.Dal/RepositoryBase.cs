using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerInquiry.Dal
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected CustomerContext CustomerContext { get; set; }

        public RepositoryBase(CustomerContext customerContext)
        {
            this.CustomerContext = customerContext;
        }

        public IQueryable<T> GetAll()
        {
            return this.CustomerContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CustomerContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.CustomerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.CustomerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.CustomerContext.Set<T>().Remove(entity);
        }
    }
}
