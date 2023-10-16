using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.City
{
    public class GetAllCItiesResponseContract
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }

        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}
