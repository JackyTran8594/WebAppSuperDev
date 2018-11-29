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
    [Table("FeedBack")]
    public class FeedBack:EntityBase
    {
        [Column("FeedBackId")]
        [StringLength(5)]
        public string FeedBackId { get; set; }

        [Column("Contents")]
        public string Contents { get; set; }

        [Column("Email")]
        [StringLength(200)]
        public string Email { get; set; }

        [Column("FullName")]
        [StringLength(50)]
        public string FullName { get; set; }

    }
}
