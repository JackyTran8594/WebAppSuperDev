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
    [RoutePrefix("api/GroupRole")]
    public class GroupRoleController : ApiController
    {

        private readonly IGroupRoleService _GroupRoleService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public GroupRoleController(IGroupRoleService service)
        {
            _GroupRoleService = service;

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
                var data = _GroupRoleService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<GroupRole>, List<GroupRoleViewModel.GroupRoleDto>>(data);
                //var pagedList = PagedList;
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
        [ResponseType(typeof(GroupRoleViewModel.GroupRoleDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _GroupRoleService.Repository.GetById(id);
                var data = Mapper.Map<GroupRole, GroupRoleViewModel.GroupRoleDto>(exist);
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
        public async Task<IHttpActionResult> Post(GroupRoleViewModel.GroupRoleDto GroupRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _GroupRoleService.Insert(GroupRole);
                    _GroupRoleService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(GroupRoleViewModel.GroupRoleDto GroupRole, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _GroupRoleService.Update(GroupRole, id);
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
                _GroupRoleService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
