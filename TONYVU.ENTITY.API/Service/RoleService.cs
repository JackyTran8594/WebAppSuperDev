using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.ENTITY.API.Helper;
using TONYVU.ENTITY.API.Repository;

namespace TONYVU.ENTITY.API.Service
{
    public interface IRoleService : IEntityServiceBase<Role>
    {
        void Insert(RoleViewModel.RoleDto Role);
        void Update(RoleViewModel.RoleDto Role, string id);
        RoleViewModel.RoleDto Detail(string id);
        void Delete(string id);
    }
    public class RoleService : EntityServiceBase<Role>, IRoleService
    {
        private string RoleCode = "Emp";

        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(RoleViewModel.RoleDto Role)
        {
            try
            {
                var data = new Role();
                if (Role != null)
                {
                    data = Mapper.Map<RoleViewModel.RoleDto, Role>(Role);
                    data.Status = 10;
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(RoleViewModel.RoleDto Role, string id)
        {
            try
            {
                if (Role != null)
                {
                    var data = Mapper.Map<RoleViewModel.RoleDto, Role>(Role);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public RoleViewModel.RoleDto Detail(string id)
        {
            var data = new RoleViewModel.RoleDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<Role, RoleViewModel.RoleDto>(exist);
                    return data;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
            return data;
        }

        public void Delete(string id)
        {
            var _id = Convert.ToInt32(id);
            try
            {
                Repository.Delete(_id);
                UnitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }
    }
}
