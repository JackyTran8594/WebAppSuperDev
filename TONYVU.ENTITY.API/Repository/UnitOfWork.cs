using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TONYVU.ENTITY.API.DAL;

namespace TONYVU.ENTITY.API.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly WebContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;
        //private Hashtable repositories;

        public UnitOfWork(WebContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                //var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                //repositories.Add(type, repositoryType);
                repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context));
            }
            return (IRepository<T>)repositories[type];
        }

        //public IRepository<T> Repository<T>() where T : class 
        //{
        //    if (repositories == null)
        //    {
        //        repositories = new Hashtable();
        //    }

        //    var type = typeof(T).Name;

        //    if (repositories.ContainsKey(type))
        //    {
        //        return (IRepository<T>)repositories[type];
        //    }

        //    var repositoryType = typeof(Repository<>);
        //    repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context));

        //    return (IRepository<T>)repositories[type];
        //}

    }
}
