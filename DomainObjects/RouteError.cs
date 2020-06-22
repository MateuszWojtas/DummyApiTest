using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class RouteError
    {
        [JsonPropertyName("message")] 
        public string Message { get; set; }
    }
}
