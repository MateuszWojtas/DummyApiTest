using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ModifyEmployeeResponse 
    {
        [JsonPropertyName("id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("salary")]
        public string EmployeeSalary { get; set; }

        [JsonPropertyName("age")]
        public string EmployeeAge { get; set; }
    }
}
