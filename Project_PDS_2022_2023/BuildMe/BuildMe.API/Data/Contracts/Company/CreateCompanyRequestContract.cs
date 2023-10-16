using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Company
{
    public class CreateCompanyRequestContract
    {
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
    }
}