using Marketify.Entity.Identity;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.PostDTOs
{
    public class CreatePostDTO
    {
  
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
      
    }
}
