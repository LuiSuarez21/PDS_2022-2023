using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Task
{
    public class CreateTaskRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("city_id")]
        public int CityId { get; set; }

        [JsonPropertyName("date_start")]
        public DateTime DateStart { get; set; }

        [JsonPropertyName("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonPropertyName("date_bidding_start")]
        public DateTime DateBiddingStart { get; set; }

        [JsonPropertyName("date_bidding_end")]
        public DateTime DateBiddingEnd { get; set; }

        [JsonPropertyName("task_status_id")]
        public int TaskStatusId { get; set; }
    }
}