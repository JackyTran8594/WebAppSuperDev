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
    [Table("User")]
    public class User : EntityBase
    {
        [Column("User_Id")]
        public string User_Id { get; set; }

        [Column("UserName")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Column("Password_User")]
        public string Password_User { get; set; }

        [Column("PhoneNumber")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column("Address_User")]
        public string Address_User { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [Column("Role_Id")]
        [StringLength(5)]
        public string Role_Id { get; set; }

        [Column("UserStatus")]
        public int UserStatus { get; set; }

    }
}
