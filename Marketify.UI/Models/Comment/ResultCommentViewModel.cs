using Marketify.UI.Models.Post;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Comment
{
    public class ResultCommentViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public ResultUserViewModel User { get; set; }
        public int PostId { get; set; }
        public ResultPostViewModel Post { get; set; }
    }
}
