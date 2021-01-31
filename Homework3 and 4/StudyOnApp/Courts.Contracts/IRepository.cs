using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Court.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Return the entity by the Id
        /// </summary>
        TEntity GetByIdAsync(int id);

        /// <summary>
        ///     Return all entities from the table
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        ///     Search by term in the table and return those entities
        /// </summary>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Return only one entity that matches the searched term
        /// </summary>
        IQueryable<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Create new entity in the database
        /// </summary>
        TEntity Add(TEntity entity);

        /// <summary>
        ///     Create multiple entities in the database
        /// </summary>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Remove netity from the database
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        ///     Remove multiple entities from the database
        /// </summary>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Return all entities from a certain table joined by another table
        /// </summary>
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Get certaing range of entities from a certain table joined by another table 
        /// </summary>
        IQueryable<Entity> GetAll<Entity>(
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class;

        /// <summary>
        ///     Get certain range of entitites from a certain table joined by another table and filtered by regular expression
        /// </summary>
        IEnumerable<Entity> Get<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class;

        /// <summary>
        ///     Get one entity from a certain table filtered by regular expression
        /// </summary>
        Entity GetOne<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        string includeProperties = null)
        where Entity : class;

        /// <summary>
        ///     Update entity in the database
        /// </summary>
        TEntity Update(TEntity entity);
    }
}
