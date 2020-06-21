using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ReadEmployee : BaseEmployee
    {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("profile_image")]
            public string ProfileImage { get; set; }
    }
}
