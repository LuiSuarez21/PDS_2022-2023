using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.JobType
{
    public class CreateJobTypeRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
