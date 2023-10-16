using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.CompanyBudget
{
    public class UpdateCompanyBudgetRequestContract
    {
        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("task_id")]
        public int TaskId { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("is_rejected")]
        public bool IsRejected { get; set; }
    }
}
