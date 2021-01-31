using Microsoft.EntityFrameworkCore;
using StudyOn.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudyOn.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UsersDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(UsersDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetByIdAsync(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return (IQueryable<TEntity>)_dbSet.SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            if (includes != null)
                includes.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return query;
        }

        protected virtual IQueryable<Entity> GetQueryable<Entity>(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        where Entity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<Entity> query = _context.Set<Entity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
        public virtual IQueryable<Entity> GetAll<Entity>(
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class
        {
            return GetQueryable<Entity>(null, orderBy, includeProperties, skip, take);
        }

        public virtual IEnumerable<Entity> Get<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where Entity : class
        {
            return GetQueryable<Entity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual Entity GetOne<Entity>(
        Expression<Func<Entity, bool>> filter = null,
        string includeProperties = "")
        where Entity : class
        {
            return GetQueryable<Entity>(filter, null, includeProperties).SingleOrDefault();
        }
        public TEntity Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
