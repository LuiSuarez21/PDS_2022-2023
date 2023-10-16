using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class Meeting : BaseObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("meeting_status_id")]
        public int MeetingStatusId { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}