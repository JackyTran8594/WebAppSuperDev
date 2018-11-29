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
    [RoutePrefix("api/TypeProduct")]
    public class TypeProductController : ApiController
    {

        private readonly ITypeProductService _TypeProductService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public TypeProductController(ITypeProductService service)
        {
            _TypeProductService = service;

        }

        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var data = _TypeProductService.Repository.DbSet.Select(o => new
            {
                Value = o.TypeCode,
                Text = o.TypeName
            }).ToList();
            return Ok(data);
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
                var data = _TypeProductService.Repository.DbSet.ToList();
                var listData = Mapper.Map<List<TypeProduct>, List<TypeProductViewModel.TypeProductDto>>(data);
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
        [ResponseType(typeof(TypeProductViewModel.TypeProductDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _TypeProductService.Repository.GetById(id);
                var data = Mapper.Map<TypeProduct, TypeProductViewModel.TypeProductDto>(exist);
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
        public async Task<IHttpActionResult> Post(TypeProductViewModel.TypeProductDto TypeProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _TypeProductService.Insert(TypeProduct);
                    _TypeProductService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(TypeProductViewModel.TypeProductDto TypeProduct, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _TypeProductService.Update(TypeProduct, id);
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
                _TypeProductService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
