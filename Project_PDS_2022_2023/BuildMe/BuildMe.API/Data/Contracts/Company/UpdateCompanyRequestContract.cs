using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Company
{
    public class UpdateCompanyRequestContract
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("vat")]
        public string VAT { get; set; }

        [JsonPropertyName("number_monthly_jobs")]
        public int NumberMonthlyJobs { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }

        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}