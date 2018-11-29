using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public interface IEntityServiceBase<T> : IServiceBase where T : class
    {
        IRepository<T> Repository { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        IEntityServiceBase<T> Include(Expression<Func<T, object>> include);
        void InsertService(T entity);
        void UpdateService(T entity);
    }
}
