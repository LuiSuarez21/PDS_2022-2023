using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class User : BaseObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("vat")]
        public string VAT { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("company_id")]
        public int? CompanyId { get; set; }

        [JsonPropertyName("user_type_id")]
        public int UserTypeId { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}