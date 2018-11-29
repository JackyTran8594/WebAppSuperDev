using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Service;
using TONYVU.ENTITY.API.Repository;

namespace TONYVU.WEB.API.ApiServices
{
    [RoutePrefix("api/Areas/User")]
    public class UserController : ApiController
    {

        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService service)
        {
            _userService = service;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("PagingRecord")]
        public async Task<IHttpActionResult> PagingRecord()
        {
            try
            {
                var data = _userService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<User>, List<UserViewModel.UserDto>>(data);
                return Ok(listData);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(UserViewModel.UserDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _userService.Repository.GetById(id);
                var data = Mapper.Map<User, UserViewModel.UserDto>(exist);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }

        }

        [Route("Post")]
        public async Task<IHttpActionResult> Post(UserViewModel.UserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Insert(user);
                    _userService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(UserViewModel.UserDto user, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Update(user, id);
                }
                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
        [Route("Delete/{id?}")]

        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                _userService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
