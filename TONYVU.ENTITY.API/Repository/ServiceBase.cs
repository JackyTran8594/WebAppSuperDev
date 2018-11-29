using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public abstract class ServiceBase : IServiceBase
    {
        private IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
