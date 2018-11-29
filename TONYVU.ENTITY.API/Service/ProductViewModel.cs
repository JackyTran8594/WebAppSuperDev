using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class ProductViewModel
    {
        public class ProductSearch
        {
               public string NameOfProduct { get; set; }
            public string Supplier { get; set; }
            public string MadeIn { get; set; }
        }

        public class ProductDto
        {
            public string Id { get; set; }
            public string NameOfProduct { get; set; }
            public string Supplier { get; set; }
            public string MadeIn { get; set; }
            public string Descriptions { get; set; }
            public string Path { get; set; }
            public decimal? Amount { get; set; }
            public string TypeOfProduct { get; set; }
            public string GroupOfProduct { get; set; }
            public decimal? PriceOfProduct { get; set; }
            public int? Status { get; set; }
        }
    }
    
}
