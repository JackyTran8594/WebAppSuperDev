using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class NewsViewModel
    {
        public class NewsSearch
        {
            public string Title { get; set; }
            public string Author { get; set; }

        }

        public class NewsDto
        {
            public string Id { get; set; }
            public string Title { get; set; }

            public string Contents { get; set; }

            public string Author { get; set; }

            public string Summary { get; set; }

            public int? Status { get; set; }
        }
    }

}
