using BuildMe.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuildMe.API.Data.Contracts.Users
{
    public class GetUserResponseContract
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("vat")]
        public string VAT { get; set; }

        [Required]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [Required]
        [JsonPropertyName("user_type_id")]
        public int UserTypeId { get; set; }

        [Required]
        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}
