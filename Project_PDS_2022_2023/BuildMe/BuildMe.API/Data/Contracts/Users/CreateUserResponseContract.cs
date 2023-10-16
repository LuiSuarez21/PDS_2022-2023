using BuildMe.Domain.Model;
using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Users
{
    public class CreateUserResponseContract
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
