using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.MeetingStatus
{
    public class CreateMeetingStatusRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
