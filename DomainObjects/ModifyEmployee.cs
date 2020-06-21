using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ModifyEmployee
    {
        [JsonPropertyName("id")] 
        public string EmployeeId { get; set; }

        [JsonPropertyName("name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("salary")]
        public string EmployeeSalary { get; set; }

        [JsonPropertyName("age")]
        public string EmployeeAge { get; set; }
    }
}