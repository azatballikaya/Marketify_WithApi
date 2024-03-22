using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.RoleDTOs
{
    public class AddUserToRoleByEmailDTO
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
