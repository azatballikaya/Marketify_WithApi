using Marketify.UI.Models.Message;
using Marketify.UI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketify.UI.Models.Chat
{
    public class ResultChatViewModel
    {
        public int ChatId { get; set; }
       
        public string UserId1 { get; set; }
        public ResultUserViewModel User1 { get; set; }
       
        public string UserId2 { get; set; }
        public ResultUserViewModel User2 { get; set; }
        public List<ResultMessageViewModel> Messages { get; set; }
    }

}
