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
    [RoutePrefix("api/FeedBack")]
    public class FeedBackController : ApiController
    {

        private readonly IFeedBackService _FeedBackService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public FeedBackController(IFeedBackService service)
        {
            _FeedBackService = service;

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
                var data = _FeedBackService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<FeedBack>, List<FeedBackViewModel.FeedBackDto>>(data);
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
        [ResponseType(typeof(FeedBackViewModel.FeedBackDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _FeedBackService.Repository.GetById(id);
                var data = Mapper.Map<FeedBack, FeedBackViewModel.FeedBackDto>(exist);
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
        public async Task<IHttpActionResult> Post(FeedBackViewModel.FeedBackDto FeedBack)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FeedBackService.Insert(FeedBack);
                    _FeedBackService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(FeedBackViewModel.FeedBackDto FeedBack, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FeedBackService.Update(FeedBack, id);
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
                _FeedBackService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
