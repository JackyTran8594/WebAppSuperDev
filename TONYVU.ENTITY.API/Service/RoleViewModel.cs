using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class RoleViewModel
    {

        public class RoleDtoSẻach
        {
            public string RoleId { get; set; }
            public string RoleName { get; set; }
        }

        public class RoleDto
        {
            public string Id { get; set; }
            public string RoleId { get; set; }
            public string RoleName { get; set; }
            public string ListRole { get; set; }
            public string Notes { get; set; }
        }

    }
}
