using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class BaseEmployee
    {
        public BaseEmployee(string name, string Age, string salary)
        {
            EmployeeName = name;
            EmployeeSalary = salary;
            EmployeeAge = Age;
        }

        [JsonPropertyName("employee_name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("employee_salary")]
        public string EmployeeSalary { get; set; }

        [JsonPropertyName("employee_age")]
        public string EmployeeAge { get; set; }
    }
}