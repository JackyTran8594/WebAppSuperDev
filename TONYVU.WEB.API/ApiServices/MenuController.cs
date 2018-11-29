using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Newtonsoft.Json.Linq;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Helper;
using TONYVU.ENTITY.API.Infrastructure;
using TONYVU.ENTITY.API.Service;

namespace TONYVU.WEB.API.ApiServices
{
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        private IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [Route("GetMenu")]
        public async Task<IHttpActionResult> GetMenu()
        {
            var data = _service.Repository.DbSet.Where(o => o.Status == 1);
            return Ok(data);
        }


        [Route("PagingRecord")]
        public async Task<IHttpActionResult> PagingRecord(JObject jsonObject)
        {
            try
            {
                var filtered = ((dynamic)jsonObject);
                var item = ((JObject)filtered.page).ToObject<PagedListItem>();
                var data = _service.Repository.DbSet;
                item.OrderBy = "Id";
                var results =
                    await
                        TONYVU.ENTITY.API.Helper.PagedList.CreatePagedList<Menu, MenuViewModel>(data, item.CurrentPage,
                            item.PageSize, 10, item.OrderBy, true);
                return Ok(results);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        public async Task<IHttpActionResult> Post(MenuViewModel item)
        {
            if (item != null)
            {
                var data = Mapper.Map<MenuViewModel, Menu>(item);
                _service.Repository.Insert(data);
                _service.UnitOfWork.Save();
                return Ok(200);
            }
            return BadRequest();
        }

        [ResponseType(typeof(MenuViewModel))]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (id != null)
            {
                var data = _service.Repository.DbSet.Find(id);
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("Put/{id?}")]
        public async Task<IHttpActionResult> Put(MenuViewModel item, string id)
        {
            if (id != null)
            {
                var exist = _service.Repository.DbSet.Find(id);
                if (exist != null)
                {
                    exist.ObjectState = ObjectState.Modified;
                    exist = Mapper.Map<MenuViewModel, Menu>(item);
                    _service.Repository.Update(exist);
                    _service.UnitOfWork.Save();
                }
                return Ok(200);
            }
            return BadRequest();
        }

    }
}
