using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class TypeProductViewModel
    {
        public class TypeProductSearch
        {
            public string TypeName { get; set; }
            public int Status { get; set; }

        }

        public class TypeProductDto
        {
            public string Id { get; set; }
            public string TypeName { get; set; }
            public string TypeCode { get; set; }
            public string Descriptions { get; set; }
            public int Status { get; set; }
        }
    }
}
