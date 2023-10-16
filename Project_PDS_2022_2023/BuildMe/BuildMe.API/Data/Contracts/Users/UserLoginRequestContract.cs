using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Users
{
    public class UserLoginRequestContract
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
