using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("Product")]
    public class Product : EntityBase
    {
        [Column("NameOfProduct")]
        [StringLength(200)]
        public string NameOfProduct { get; set; }

        [Column("Supplier")]
        [StringLength(100)]
        public string Supplier { get; set; }

        [Column("MadeIn")]
        [StringLength(50)]
        public string MadeIn { get; set; }

        [Column("Descriptions")]
        [StringLength(500)]
        public string Descriptions { get; set; }

        [Column("Path")]
        public string Path { get; set; }

        [Column("Amount")]
        public decimal? Amount { get; set; }

        [Column("TypeOfProduct")]
        [StringLength(20)]
        public string TypeOfProduct { get; set; }

        [Column("GroupOfProduct")]
        [StringLength(20)]
        public string GroupOfProduct { get; set; }

        [Column("PriceOfProduct")]
        public decimal? PriceOfProduct { get; set; }

        [Column("Status")]
        public int? Status { get; set; }
    }
}
