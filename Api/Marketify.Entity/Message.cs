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
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public int MyProperty { get; set; }
    }
}
