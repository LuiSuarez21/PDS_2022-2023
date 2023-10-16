﻿using System.Text.Json.Serialization;

namespace BuildMe.Domain.Model
{
    public class CompanyJobType
    {
        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("job_type_id")]
        public int JobTypeId { get; set; }

        [JsonPropertyName("average_price")]
        public double AveragePrice { get; set; }
    }
}