using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.City
{
    public class CreateCityRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
    }
}
