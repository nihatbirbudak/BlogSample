using BlogSample.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogSample.Core.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity<int>
    {
        private readonly DbContext context;
        public RepositoryBase(DbContext _context)
        {
            context = _context;
        }

        public T Add(T entity)
        {
            return context.Set<T>().Add(entity) as T;
        }

        public void Delete(T entity)
        {
            ChangeTrackerDetachedObject(entity);
            var dbSet = context.Set<T>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter, null, null).SingleOrDefault();
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include.Name);
            }
            return query;
        }

        protected virtual IQueryable<T> GetQueryable(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null, int? take = null
            )
        {
            IQueryable<T> query = context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = query.Include(include);
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

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include = null)
        {
            return GetQueryable(filter, include, null);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, include, orderBy, skip, take);
        }

        public IQueryable<T> GetAll()
        {
            return Get(null, null, null, null);
        }

        public T GetIncludes(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetQueryable(filter, null, null);
            foreach (var include in includes)
            {
                query = query.Include(include.Name);
            }
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
            ChangeTrackerDetachedObject(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        private void ChangeTrackerDetachedObject(T entity)
        {
            var local = context.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
