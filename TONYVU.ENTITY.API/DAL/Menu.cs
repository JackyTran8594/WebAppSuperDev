using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("Menu")]
    public class Menu : EntityBase
    {
        [Column("State")]
        [StringLength(100)]
        public string State { get; set; }

        [Column("MenuId")]
        [StringLength(10)]
        public string MenuId { get; set; }

        [Column("Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("ParentMenu")]
        [StringLength(10)]
        public string ParentMenu { get; set; }

        [Column("IsHome")]
        public bool IsHome { get; set; }

        [Column("Status")]
        public int? Status { get; set; }

        [Column("OrdinalNumber")]
        public int? OrdinalNumber { get; set; }

    }
}
