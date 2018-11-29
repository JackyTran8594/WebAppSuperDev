using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Helper
{
    public class PagedListResult<T>
    {
        public int CurrentPage { get; set; }
        public int FromItem { get; set; }
        public int ToItem { get; set; }
        public int ItemPerPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public string NextPageUrl { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

    [Serializable]
    [DataContract]
    public class PagedListItem
    {
        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int ItemPerPage { get; set; }

        [DataMember]
        public int FromItem { get; set; }

        [DataMember]
        public int ToItem { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int TotalPage { get; set; }

        [DataMember]
        public int TotalItems { get; set; }

        [DataMember]
        public string OrderBy { get; set; }

        public PagedListItem(int currentpage,int itemperpage,int fromitem, int toitem ,int pagesize, int totalpage, int totalitems, string orderby)
        {
            CurrentPage = currentpage;
            ItemPerPage = itemperpage;
            FromItem = fromitem;
            ToItem = toitem;
            PageSize = pagesize;
            TotalPage = totalpage;
            TotalItems = totalitems;
            OrderBy = orderby;
        }
    }
}
