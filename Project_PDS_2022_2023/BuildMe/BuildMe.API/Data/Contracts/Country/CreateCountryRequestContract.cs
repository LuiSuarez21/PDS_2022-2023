using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Country
{
    public class CreateCountryRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}