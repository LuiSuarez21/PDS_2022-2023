using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.CompanyCity
{
    public class CreateCompanyCityRequestContract
    {
        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("city_id")]
        public int CityId { get; set; }
    }
}
