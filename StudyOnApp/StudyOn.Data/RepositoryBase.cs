using Microsoft.EntityFrameworkCore;
using StudyOn.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudyOn.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected postgresContext RepositoryContext { get; set; }
        public RepositoryBase(postgresContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
