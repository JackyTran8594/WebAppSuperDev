using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public interface IUnitOfWork: IUnitOfWorkInstanced
    {
        void Save();
        void Dispose(bool disposing);
    }

    public interface IUnitOfWorkInstanced: IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
    }
}
