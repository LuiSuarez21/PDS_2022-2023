using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class BaseObject
    {
        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}