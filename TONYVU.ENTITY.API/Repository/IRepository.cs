using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(object id);
        T Insert(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Update(T entity);
    }
}
