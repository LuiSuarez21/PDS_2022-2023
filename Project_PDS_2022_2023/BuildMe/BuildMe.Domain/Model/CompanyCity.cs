using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class CompanyCity
    {
        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("city_id")]
        public int CityId { get; set; }
    }
}