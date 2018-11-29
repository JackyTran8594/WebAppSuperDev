using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class FeedBackViewModel
    {
        public class FeedBackSearch
        {
            public string Email { get; set; }
            public string FullName { get; set; }

        }

        public class FeedBackDto
        {
            public string Id { get; set; }
            public string FeedBackId { get; set; }
            public string Contents { get; set; }
            public string Email { get; set; }
            public string FullName { get; set; }
        }
    }

}
