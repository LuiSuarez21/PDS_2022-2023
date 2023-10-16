using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.UserTypes
{
    public class UpdateUserTypeRequestContract
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}
