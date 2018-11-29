using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public class EntityServiceBase<T> : ServiceBase, IEntityServiceBase<T> where T : class
    {
        public EntityServiceBase(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Includes = new List<Expression<Func<T, object>>>();
        }

        public virtual IRepository<T> Repository
        {
            get { return UnitOfWork.Repository<T>(); }
        }
        public virtual List<Expression<Func<T, object>>> Includes { get; private set; }
        public virtual IEntityServiceBase<T> Include(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
            ((IQueryable<T>)Repository.DbSet).Include(include);
            return this;
        }
        public virtual void InsertService(T entity)
        {
            Repository.Insert(entity);
        }

        public virtual void UpdateService(T entity)
        {
            Repository.Update(entity);
        }

    }
}
