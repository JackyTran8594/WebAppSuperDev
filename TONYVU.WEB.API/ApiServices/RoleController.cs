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
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {

        private readonly IRoleService _RoleService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public RoleController(IRoleService service)
        {
            _RoleService = service;

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
                var data = _RoleService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<Role>, List<RoleViewModel.RoleDto>>(data);
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
        [ResponseType(typeof(RoleViewModel.RoleDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _RoleService.Repository.GetById(id);
                var data = Mapper.Map<Role, RoleViewModel.RoleDto>(exist);
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
        public async Task<IHttpActionResult> Post(RoleViewModel.RoleDto Role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _RoleService.Insert(Role);
                    _RoleService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(RoleViewModel.RoleDto Role, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _RoleService.Update(Role, id);
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
                _RoleService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
