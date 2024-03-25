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
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public string UserId { get; set; }
        

    }
}
