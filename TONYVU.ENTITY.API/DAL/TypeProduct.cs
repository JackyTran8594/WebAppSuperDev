
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("TypeProduct")]
    public class TypeProduct: EntityBase
    {
        [Column("TypeName")]
        [StringLength(100)]
        public string TypeName { get; set; }

        [Column("TypeCode")]
        [StringLength(10)]
        public string TypeCode { get; set; }

        [Column("Descriptions")]
        [StringLength(500)]
        public string Descriptions { get; set; }

        [Column("Status")]
        public int Status { get; set; }

    }
}
