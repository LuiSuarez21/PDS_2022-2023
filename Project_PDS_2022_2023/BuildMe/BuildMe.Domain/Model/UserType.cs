using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class UserType : BaseObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}