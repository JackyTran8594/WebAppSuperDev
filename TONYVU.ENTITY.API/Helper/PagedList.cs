using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;


namespace TONYVU.ENTITY.API.Helper
{
    public static class PagedList
    {
        public static async Task<PagedListResult<TEntity>> CreatePagedList<T, TEntity>(IQueryable<T> queryable,
            int page, int pageSize ,int itemPerPage, string orderBy, bool ascending)
        {
            var skipAmount = itemPerPage * (page - 1);
            var projection =
                queryable.OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(itemPerPage)
                    .ProjectTo<TEntity>();

            var totalNumberOfRecord = await queryable.CountAsync();
            var results = await projection.ToListAsync();
            var mod = totalNumberOfRecord % itemPerPage;
            var totalPageCount = (totalNumberOfRecord / itemPerPage) + (mod == 0 ? 0 : 1);
            var fromitem = (page - 1)*itemPerPage + 1;
            var toitem = 0;
            if (page == totalPageCount)
            {
                toitem = totalNumberOfRecord;
            }
            else
            {
                toitem = fromitem + itemPerPage - 1;
            }
            //string url = Url.Link
            //var nextPageUrl = page == totalPageCount
            //    ? null
            //: Url?.Link("DefaultApi", new
            //{
            //    page = page + 1,
            //    pageSize,
            //    orderBy,
            //    ascending
            //});

            return new PagedListResult<TEntity>()
            {
                Results = results,
                CurrentPage = page,
                PageSize = pageSize,
                FromItem = fromitem,
                ToItem = toitem,
                ItemPerPage = results.Count,
                TotalPages = totalPageCount,
                TotalItems = totalNumberOfRecord,
                //NextPageUrl = nextPageUrl
            };
        }


    }
}
