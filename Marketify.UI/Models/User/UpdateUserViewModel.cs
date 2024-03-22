using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marketify.UI.Models.User
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }
        public string Job { get; set; }
        public bool IsApproved { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        [Compare("Password", ErrorMessage = "Parola Uyuşmuyor...")]
        public string PasswordCheck { get; set; }

        public string PhoneNumber { get; set; }
    }
}
