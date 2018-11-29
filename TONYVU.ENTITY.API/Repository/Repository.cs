using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TONYVU.ENTITY.API.DAL;

namespace TONYVU.ENTITY.API.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private WebContext _context;
        //internal DbSet<T> dbSet;
        private readonly DbSet<T> _dbSet;
        public Repository(WebContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public DbSet<T> DbSet
        {
            get
            {
                return _dbSet;
            }
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);   
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
