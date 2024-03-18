using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        
            
            public string userName { get; set; }
            public string email { get; set; }
            public bool emailConfirmed { get; set; }
        public string Password { get; set; }
        public string securityStamp { get; set; }
            public string concurrencyStamp { get; set; }
            public string phoneNumber { get; set; }
            public bool phoneNumberConfirmed { get; set; }
            public bool twoFactorEnabled { get; set; }
            public DateTime lockoutEnd { get; set; }
            public bool lockoutEnabled { get; set; }
            public int accessFailedCount { get; set; }
            public string job { get; set; }
            public bool isApproved { get; set; }
        


    }
}
