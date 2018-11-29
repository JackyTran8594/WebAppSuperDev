using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    public class EntityBase : Entity
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CreateBy")]
        [StringLength(100)]
        public string CreateBy { get; set; }

        [Column("CreateDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        [Column("UpdateBy")]
        [StringLength(100)]
        public string UpdateBy { get; set; }

        [Column("UpdateDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDate { get; set; }


        [Column("DeleteBy")]
        [StringLength(100)]
        public string DeleteBy { get; set; }

        [Column("DeleteDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? DeleteDate { get; set; }
    }
}
