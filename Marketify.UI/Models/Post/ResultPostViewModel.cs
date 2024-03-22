using Marketify.UI.Models.Comment;
using Marketify.UI.Models.Like;
using Marketify.UI.Models.Offer;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Post
{
    public class ResultPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public ResultUserViewModel User { get; set; }
        public List<ResultCommentViewModel> Comments { get; set; }
        public List<ResultLikeViewModel> Likes { get; set; }
        public List<ResultOfferViewModel> Offers { get; set; }
    }
}
