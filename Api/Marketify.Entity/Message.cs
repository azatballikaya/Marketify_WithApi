using Marketify.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public User Sender { get; set; }
        [ForeignKey("Recipient")]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}
