using Marketify.UI.Models.Post;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Offer
{
    public class CreateOfferViewModel
    {
        public double Price { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
