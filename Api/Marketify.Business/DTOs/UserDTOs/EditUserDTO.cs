using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.UserDTOs
{
    public class EditUserDTO
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }


        public string phoneNumber { get; set; }


        public string job { get; set; }
        public bool isApproved { get; set; } = false;
    }
}
