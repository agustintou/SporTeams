using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ST.Domain.Base;
using ST.Infrastructure.Context;
using ST.Repository.Base;

namespace ST.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected DataContext Context;

        public Repository()
            : this(new DataContext())
        {

        }

        public Repository(DataContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado)
        {
            return Context.Set<T>().AsNoTracking().Where(predicado);
        }

        public IEnumerable<T> GetBYFilter(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties.Split(','))

            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public T GetById(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault(x => x.Id == id);
        }

        public T GetById(long id, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var includeProperty in includeProperties.Split(','))

            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
