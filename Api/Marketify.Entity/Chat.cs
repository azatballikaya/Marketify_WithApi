using Marketify.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Entity
{
    public class Chat
    {
        public int ChatId { get; set; }
        [ForeignKey("User1")]
        public string UserId1 { get; set; }
        public User User1 { get; set; }
        [ForeignKey("User2")]
        public string UserId2 { get; set; }
        public User User2 { get; set; }
        public  List<Message> Messages { get; set; }
    }
}
