using Marketify.Entity.Identity;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
       
        public string MessageContent { get; set; }
       
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
      
    }
}
