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
    public interface IGroupRoleService : IEntityServiceBase<GroupRole>
    {
        void Insert(GroupRoleViewModel.GroupRoleDto GroupRole);
        void Update(GroupRoleViewModel.GroupRoleDto GroupRole, string id);
        GroupRoleViewModel.GroupRoleDto Detail(string id);
        void Delete(string id);
    }
    public class GroupRoleService : EntityServiceBase<GroupRole>, IGroupRoleService
    {
        private string GroupRoleCode = "Emp";

        public GroupRoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(GroupRoleViewModel.GroupRoleDto GroupRole)
        {
            try
            {
                var data = new GroupRole();
                if (GroupRole != null)
                {
                    data = Mapper.Map<GroupRoleViewModel.GroupRoleDto, GroupRole>(GroupRole);
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

        public void Update(GroupRoleViewModel.GroupRoleDto GroupRole, string id)
        {
            try
            {
                if (GroupRole != null)
                {
                    var data = Mapper.Map<GroupRoleViewModel.GroupRoleDto, GroupRole>(GroupRole);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public GroupRoleViewModel.GroupRoleDto Detail(string id)
        {
            var data = new GroupRoleViewModel.GroupRoleDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<GroupRole, GroupRoleViewModel.GroupRoleDto>(exist);
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
