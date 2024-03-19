using Marketify.Entity.Identity;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.CommentDTOs
{
    public class CreateCommentDTO
    {
       
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
       
        public int PostId { get; set; }
       
    }
}
