using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class BaseEmployee
    {
        [JsonPropertyName("employee_name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("employee_salary")]
        public string EmployeeSalary { get; set; }

        [JsonPropertyName("employee_age")]
        public string EmployeeAge { get; set; }
    }
}
