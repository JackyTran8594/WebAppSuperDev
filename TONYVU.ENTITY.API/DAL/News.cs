using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    [Table("News")]
    public class News : EntityBase
    {
        [Column("Title")]
        [StringLength(200)]
        public string Title { get; set; }

        [Column("Contents")]
        public string Contents { get; set; }

        [Column("Author")]
        [StringLength(100)]
        public string Author { get; set; }

        [Column("Summary")]
        [StringLength(200)]
        public string Summary { get; set; }

        [Column("Status")]
        public int? Status { get; set; }
    }
}
