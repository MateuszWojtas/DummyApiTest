using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ReadEmployeeList
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<ReadEmployee> EmployeeList { get; set; }
    }
}
