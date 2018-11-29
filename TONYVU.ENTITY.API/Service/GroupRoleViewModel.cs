using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class GroupRoleViewModel
    {

        public class GroupRoleDtoSẻach
        {
            public string GroupRoleId { get; set; }
            public string GroupRoleName { get; set; }
        }

        public class GroupRoleDto
        {
            public string Id { get; set; }
            public string GroupRoleId { get; set; }
            public string GroupRoleName { get; set; }
            public string ListRole { get; set; }
            public string Notes { get; set; }
        }

    }
}
