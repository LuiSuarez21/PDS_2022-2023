using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.JobType
{
    public class UpdateJobTypeRequestContract
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
