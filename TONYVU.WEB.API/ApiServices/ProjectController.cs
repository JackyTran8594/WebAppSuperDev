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
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {

        private readonly IProjectService _ProjectService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public ProjectController(IProjectService service)
        {
            _ProjectService = service;

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
                var data = _ProjectService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<Project>, List<ProjectViewModel.ProjectDto>>(data);
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
        [ResponseType(typeof(ProjectViewModel.ProjectDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _ProjectService.Repository.GetById(id);
                var data = Mapper.Map<Project, ProjectViewModel.ProjectDto>(exist);
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
        public async Task<IHttpActionResult> Post(ProjectViewModel.ProjectDto Project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ProjectService.Insert(Project);
                    _ProjectService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(ProjectViewModel.ProjectDto Project, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ProjectService.Update(Project, id);
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
                _ProjectService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
