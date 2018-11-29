using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class ProjectViewModel
    {
        public class ProjectSearch
        {
            public string ProjectName { get; set; }

        }

        public class ProjectDto
        {
            public string Id { get; set; }
            public string ProjectId { get; set; }
            public string ProjectName { get; set; }

            public string Descriptions { get; set; }
            public string Notes { get; set; }
            public DateTime? CreateDate { get; set; }
        }
    }

}
