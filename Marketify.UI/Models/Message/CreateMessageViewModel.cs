using Marketify.UI.Models.Chat;
using Marketify.UI.Models.User;

namespace Marketify.UI.Models.Message
{
    public class CreateMessageViewModel
    {
        public string MessageContent { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }
    }
}
