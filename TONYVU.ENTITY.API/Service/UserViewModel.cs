using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Service
{
    public class UserViewModel
    {
        public class UserSearch
        {
            public string User_Id { get; set; }
            public string UserName { get; set; }
            public string Password_User { get; set; }
            public string PhoneNumber { get; set; }
            public string Address_User { get; set; }
            public string Notes { get; set; }
            public string Role_Id { get; set; }
            public int UserStatus { get; set; }

        }

        public class UserDto
        {
            public string id { get; set; }
            public string User_Id { get; set; }
            public string UserName { get; set; }
            public string Password_User { get; set; }
            public string PhoneNumber { get; set; }
            public string Address_User { get; set; }
            public string Notes { get; set; }
            public string Role_Id { get; set; }
            public int UserStatus { get; set; }
            public DateTime? CreateDate { get; set; }

        }
    }

    public class AuthenticationUser
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    
}
