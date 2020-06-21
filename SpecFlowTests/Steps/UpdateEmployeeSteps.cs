using DomainObjects;
using FluentAssertions;
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
            _employeeUpdatedName = newName != "null" ? newName : string.Empty;
            _employeeUpdatedAge = newAge != "null" ? newAge : string.Empty;
            _employeeUpdatedSalary = newSalary != "null" ? newSalary : string.Empty;
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
            var expected = new ReadSingleEmployee
            {
                Status = "success",
                Employee = new ReadEmployee
                {
                    EmployeeName = _employeeUpdatedName,
                    EmployeeSalary = _employeeUpdatedSalary,
                    EmployeeAge = _employeeUpdatedAge,
                    ProfileImage = "",
                    Id = _employeeId
                }
            };
            var actual = JsonSerializer.Deserialize<ReadSingleEmployee>(_restResponse.Content);

            actual.Should().BeEquivalentTo(expected);

            //Assert.AreEqual(expected.Employee.EmployeeName, actual.Employee.EmployeeName, "Employee Name");
            //Assert.AreEqual(expected.Employee.EmployeeSalary, actual.Employee.EmployeeSalary, "Employee Salary");
            //Assert.AreEqual(expected.Employee.EmployeeAge, actual.Employee.EmployeeAge, "Employee Age");
            //Assert.IsNotNull(expected.Employee.Id,actual.Employee.Id, "Employee Id");
        }
    }
}