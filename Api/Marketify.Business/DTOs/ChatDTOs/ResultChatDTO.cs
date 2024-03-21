using Marketify.Entity.Identity;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.ChatDTOs
{
    public class ResultChatDTO
    {
        public int ChatId { get; set; }
   
        public string UserId1 { get; set; }
        public User User1 { get; set; }
       
        public string UserId2 { get; set; }
        public User User2 { get; set; }
        public List<Message> Messages { get; set; }
    }
}
