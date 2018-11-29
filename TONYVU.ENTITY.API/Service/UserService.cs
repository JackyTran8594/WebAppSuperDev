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
    public interface IUserService : IEntityServiceBase<User>
    {
        void Insert(UserViewModel.UserDto user);
        void Update(UserViewModel.UserDto user, string id);
        UserViewModel.UserDto Detail(string id);
        void Delete(string id);
    }
    public class UserService : EntityServiceBase<User>, IUserService
    {
        private string userCode = "Emp";

        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(UserViewModel.UserDto user)
        {
            try
            {
                var data = new User();
                if (user != null)
                {
                    data = Mapper.Map<UserViewModel.UserDto, User>(user);
                    data.User_Id = Guid.NewGuid().ToString();
                    data.UserStatus = 10;
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(UserViewModel.UserDto user, string id)
        {
            try
            {
                if (user != null)
                {
                    var data = Mapper.Map<UserViewModel.UserDto, User>(user);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public UserViewModel.UserDto Detail(string id)
        {
            var data = new UserViewModel.UserDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<User, UserViewModel.UserDto>(exist);
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
