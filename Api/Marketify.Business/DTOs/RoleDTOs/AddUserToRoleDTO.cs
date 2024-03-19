using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.RoleDTOs
{
    public class AddUserToRoleDTO
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
