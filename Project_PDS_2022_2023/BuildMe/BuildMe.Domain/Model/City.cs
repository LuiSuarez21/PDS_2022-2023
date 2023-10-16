using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class City : BaseObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}