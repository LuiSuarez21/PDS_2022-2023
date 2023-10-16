using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class CompanyBudget
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