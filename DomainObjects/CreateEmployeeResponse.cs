﻿using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class CreateEmployeeResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public ModifyEmployeeResponse Employee { get; set; }
    }
}