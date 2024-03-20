using Marketify.Entity.Identity;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs
{
    public class CreateOfferDTO
    {
        
        public double Price { get; set; }
        public int PostId { get; set; }
        
        public string UserId { get; set; }
       
    }
}
