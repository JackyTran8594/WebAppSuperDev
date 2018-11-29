using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Repository;

namespace TONYVU.ENTITY.API.Service
{
    public interface IMenuService: IEntityServiceBase<Menu>
    {
        
    }
    public class MenuService: EntityServiceBase<Menu>, IMenuService
    {
        public MenuService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
