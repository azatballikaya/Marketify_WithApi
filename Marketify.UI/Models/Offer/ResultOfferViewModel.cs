using Marketify.UI.Models.Post;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Offer
{
    public class ResultOfferViewModel
    {
        public int OfferId { get; set; }
        public double Price { get; set; }
        public int PostId { get; set; }
        public ResultPostViewModel Post { get; set; }
        public string UserId { get; set; }
        public ResultUserViewModel User { get; set; }
    }
}
