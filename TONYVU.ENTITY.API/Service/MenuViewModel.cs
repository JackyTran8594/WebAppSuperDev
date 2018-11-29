using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class MenuViewModel
    {
        public string State { get; set; }
        public string MenuId { get; set; }
        public string Name { get; set; }
        public string ParentMenu { get; set; }
        public int? Status { get; set; }

    }
}
