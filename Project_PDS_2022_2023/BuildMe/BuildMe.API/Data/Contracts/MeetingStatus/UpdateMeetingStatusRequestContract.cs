using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.MeetingStatus
{
    public class UpdateMeetingStatusRequestContract
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }

        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}
