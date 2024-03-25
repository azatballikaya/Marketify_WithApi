using Marketify.UI.Models.Comment;
using Marketify.UI.Models.Like;
using Marketify.UI.Models.Offer;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Post
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClickCount { get; set; }
        public string UserId { get; set; }
        
     
    
    }
}
