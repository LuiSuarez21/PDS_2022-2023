using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.TaskStatus
{
    public class CreateTaskStatusRequestContract
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
