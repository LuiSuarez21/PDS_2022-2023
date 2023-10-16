using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Users
{
    public class UserLoginResponseContract
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
    }
}
