using Marketify.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Entity
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
