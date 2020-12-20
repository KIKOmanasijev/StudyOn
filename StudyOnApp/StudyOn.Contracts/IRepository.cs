using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudyOn.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdAsync(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<Entity> GetAll<Entity>(
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class;

        IEnumerable<Entity> Get<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class;

        Entity GetOne<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        string includeProperties = null)
        where Entity : class;
        TEntity Update(TEntity entity);
    }
}
