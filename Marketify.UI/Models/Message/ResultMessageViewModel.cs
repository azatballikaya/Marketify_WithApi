using Marketify.UI.Models.Chat;
using Marketify.UI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketify.UI.Models.Message
{
    public class ResultMessageViewModel
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public int ChatId { get; set; }
        public ResultChatViewModel Chat { get; set; }
      
        public string SenderId { get; set; }
        public ResultUserViewModel Sender { get; set; }
       
        public string RecipientId { get; set; }
        public ResultUserViewModel Recipient { get; set; }
    }
}
