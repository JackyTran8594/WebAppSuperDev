using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Repository
{
    public interface IServiceBase
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
