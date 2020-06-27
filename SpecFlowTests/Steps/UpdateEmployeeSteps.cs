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
            string buildBody;
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/update/{_employeeId}");
            _restRequest = RestHelper.PrepareUpdateEmployeeRequest(_employeeUpdatedName, _employeeUpdatedSalary, _employeeUpdatedAge, out buildBody);
            _restRequest.AddHeader("Cookie", "PHPSESSID=061aa161aefa9611b5fe5b4aaa1b10f0");
            _restRequest.AddParameter("text/plain", buildBody, ParameterType.RequestBody);
        }

       

        [Given(@"I created update request without Body")]
        public void GivenIPreparedRequestWithoutBody()
        {
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/update/7");
            _restRequest = new RestRequest("", Method.PUT);
            _restRequest.AddHeader("Content-Type", "text/plain");
            _restRequest.AddHeader("Cookie", "PHPSESSID=061aa161aefa9611b5fe5b4aaa1b10f0");
        }


        [Then(@"Response with the same id and new name is shown")]
        public void ThenResponseWithTheSameIdAndNewNameIsShown()
        {
            var expected = new ReadSingleEmployee
            {
                Status = "success",
                Employee = new ReadEmployee(_employeeUpdatedName, _employeeUpdatedAge, _employeeUpdatedSalary, _employeeId, "")
            };
            var actual = JsonSerializer.Deserialize<ReadSingleEmployee>(_restResponse.Content);

            actual.Should().BeEquivalentTo(expected);

            //Assert.AreEqual(expected.Employee.EmployeeName, actual.Employee.EmployeeName, "Employee Name");
            //Assert.AreEqual(expected.Employee.EmployeeSalary, actual.Employee.EmployeeSalary, "Employee Salary");
            //Assert.AreEqual(expected.Employee.EmployeeAge, actual.Employee.EmployeeAge, "Employee Age");
            //Assert.IsNotNull(expected.Employee.Id,actual.Employee.Id, "Employee Id");
        }

        [Then(@"Response with null values is shown")]
        public void ThenResponseWithNullValuesIsShown()
        {
            var expected = new ReadSingleEmployee
            {
                Status = "success",
                Employee = new ReadEmployee(null, null,null, "7", "")
            };
            var actual = JsonSerializer.Deserialize<ReadSingleEmployee>(_restResponse.Content);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}