using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("GroupRole")]
    public class GroupRole : EntityBase
    {
        [Column("GroupRoleId")]
        [StringLength(5)]
        public string GroupRoleId { get; set; }

        [Column("GroupRoleName")]
        [StringLength(200)]
        public string GroupRoleName { get; set; }

        [Column("ListRole")]
        [StringLength(100)]
        public string ListRole { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [Column("Status")]
        public int Status { get; set; }

    }
}
