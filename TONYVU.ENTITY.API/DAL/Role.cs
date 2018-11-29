using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("Role")]
    public class Role : EntityBase
    {
        [Column("RoleId")]
        [StringLength(5)]
        public string RoleId { get; set; }

        [Column("RoleName")]
        [StringLength(100)]
        public string RoleName { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [Column("GroupRoleId")]
        [StringLength(5)]
        public string GroupRoleId { get; set; }

        [Column("Status")]
        public int Status { get; set; }
    }
}
