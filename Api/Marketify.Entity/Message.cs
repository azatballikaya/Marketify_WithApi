using Marketify.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int MyProperty { get; set; }
    }
}
