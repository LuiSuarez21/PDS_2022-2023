using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.UserTypes
{
    public class CreateUserTypeRequestContract
    {
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
