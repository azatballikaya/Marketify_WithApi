using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Entity.Identity
{
    public class User:IdentityUser
    {
        public string Job { get; set; }
        public bool IsApproved { get; set; }
     
    }
}
