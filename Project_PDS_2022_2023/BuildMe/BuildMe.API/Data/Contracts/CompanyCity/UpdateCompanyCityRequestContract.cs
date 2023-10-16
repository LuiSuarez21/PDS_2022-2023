using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.CompanyCity
{
    public class UpdateCompanyCityRequestContract
    {
        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("city_id")]
        public int CityId { get; set; }
    }
}
