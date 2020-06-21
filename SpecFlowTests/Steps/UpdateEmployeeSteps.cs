using DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "UpdateEmployee")]
    public class UpdateEmployeeSteps : BaseSteps
    {
        private string _employeeUpdatedName; 
        private string _employeeId;
        private string _employeeUpdatedSalary;
        private string _employeeUpdatedAge;

        [Given(@"I Have employee with id (.*)")]
        public void GivenIHaveEmployeeWithId(string p0)
        {
            _employeeId = p0;
        }
        
        [Given(@"I update employee data with new values (.*),(.*),(.*)")]
        public void GivenIUpdateEmployeeDataWithNewValues(string newName, string newSalary, string newAge)
        {
            _employeeUpdatedName = newName != "null" ? newName : null;
            _employeeUpdatedAge = newAge != "null" ? newAge : null;
            _employeeUpdatedSalary = newSalary != "null" ? newSalary : null;
        }

        [Given(@"I created update request with updated data")]
        public void GivenICreateUpdateRequestWithNewData()
        {
            var jsonRaw = $"{{\"name\":\"{_employeeUpdatedName}\",\"salary\":\"{_employeeUpdatedSalary}\",\"age\":\"{_employeeUpdatedAge}\"}}";
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/update/{_employeeId}");
            _restRequest = new RestRequest("", Method.PUT);
            _restRequest.AddHeader("Content-Type", "text/plain");
            _restRequest.AddHeader("Cookie", "PHPSESSID=7a8bb0856b7cd9fe1b7c083709d0fb7d");
            _restRequest.AddParameter("text/plain", jsonRaw, ParameterType.RequestBody);
        }

        [Then(@"Response with the same id and new name is shown")]
        public void ThenResponseWithTheSameIdAndNewNameIsShown()
        {
            var expected = new ModifyEmployeeResponse
            {
                EmployeeName = _employeeUpdatedName,
                EmployeeSalary = _employeeUpdatedSalary,
                EmployeeAge = _employeeUpdatedAge
            };
            var actual = JsonSerializer.Deserialize<ModifyEmployeeResponse>(_restResponse.Content);

            Assert.AreEqual(expected.EmployeeName, actual.EmployeeName, "Employee Name");
            Assert.AreEqual(expected.EmployeeSalary, actual.EmployeeSalary, "Employee Salary");
            Assert.AreEqual(expected.EmployeeAge, actual.EmployeeAge, "Employee Age");
            Assert.IsNotNull(actual.EmployeeId,  "Employee Id");
        }
    }
}