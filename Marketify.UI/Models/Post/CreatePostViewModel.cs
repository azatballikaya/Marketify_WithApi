using System.Text.Json.Serialization;

namespace Marketify.UI.Models.Post
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public IFormFile Image { get; set; }
        public double ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
       
    }
}
