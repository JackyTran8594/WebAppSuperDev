using System;
using System.Collections.Generic;
using System.IO;
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
using TONYVU.ENTITY.API;
using TONYVU.ENTITY.API.Helper;
using PagedList = TONYVU.ENTITY.API.Helper.PagedList;

namespace TONYVU.WEB.API.ApiServices
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {

        private readonly IProductService _ProductService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public ProductController(IProductService service)
        {
            _ProductService = service;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("PagingRecord")]
        public async Task<IHttpActionResult> PagingRecord(JObject jsonObject)
        {
            try
            {
                var filtered = ((dynamic) jsonObject);
                var item = ((JObject) filtered.page).ToObject<PagedListItem>();
                item.OrderBy = "Id";
                var data = _ProductService.Repository.DbSet.AsQueryable();
                var results =
                    await
                        TONYVU.ENTITY.API.Helper.PagedList.CreatePagedList<Product, ProductViewModel.ProductDto>(data,
                            item.CurrentPage, item.PageSize, 10 ,item.OrderBy, true);
                return Ok(results);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(ProductViewModel.ProductDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var exist = _ProductService.Repository.GetById(id);
                var data = Mapper.Map<Product, ProductViewModel.ProductDto>(exist);
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
        public async Task<IHttpActionResult> Post(ProductViewModel.ProductDto product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    //2 - Air Conditioner
                    //1 - Elevator
                    var pathElevator = "~/ UploadFiles/Elevator";
                    var pathAirConditioner = "~/UploadFiles/AirConditioner";

                    if (product.Path == 2.ToString())
                    {
                        product.Path = pathAirConditioner;
                    }
                    else if(product.Path == 1.ToString())
                    {
                        product.Path = pathElevator;
                    }
                    else
                    {
                        product.Path = "";
                    }
                    _ProductService.Insert(product);
                    _ProductService.UnitOfWork.Save();
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }


        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(ProductViewModel.ProductDto Product, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ProductService.Update(Product, id);
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
                _ProductService.Delete(id);

                return Ok(200);
            }
            catch (Exception exception)
            {

                throw new Exception();
            }
        }
    }
}
