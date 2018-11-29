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
    [Table("Project")]
    public class Project:EntityBase
    {
        [Column("ProjectId")]
        [StringLength(5)]
        public string ProjectId { get; set; }

        [Column("ProjectName")]
        [StringLength(200)]
        public string ProjectName { get; set; }

        [Column("Descriptions")]
        [StringLength(500)]
        public string Descriptions { get; set; }

        [Column("Notes")]
        [StringLength(500)]
        public string Notes { get; set; }

    }
}
