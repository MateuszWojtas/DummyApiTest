using DomainObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Text.Json;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "CreateEmployee")]
    public class CreateEmployeeSteps : BaseSteps
    {
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }
        public string EmployeeAge { get; set; }

        [Given(@"I have entered (.*) as a name of employee")]
        public void GivenIHaveEnteredNameOfEmployee(string p0)
        {
            EmployeeName = p0 == "null" ? string.Empty : p0;
        }

        [Given(@"I have entered (.*) as salary")]
        public void GivenIHaveEnteredAsSalary(string p0)
        {
            EmployeeSalary = p0 == "null" ? string.Empty : p0;
        }

        [Given(@"I have entered (.*) as  age")]
        public void GivenIHaveEnteredAsAge(string p0)
        {
            EmployeeAge = p0 == "null" ? string.Empty : p0;
        }

        [Given(@"Request is prepared")]
        public void GivenRequestIsPrepared()
        {
            _restClient = new RestClient("http://dummy.restapiexample.com/api/v1/create");
            _restRequest = RestHelper.PrepareCreateEmployeeRequest(EmployeeName, EmployeeSalary, EmployeeAge);
        }

        [Then(@"Guest should be created with data - (.*),(.*),(.*)")]
        public void ThenGuestShouldBeCreatedWithData(string name, string salary, string age)
        {
            var expectedEmployee = new ModifyEmployee
            {
                EmployeeAge = age == "null" ? string.Empty : age,
                EmployeeSalary = salary == "null" ? string.Empty : salary,
                EmployeeName = name == "null" ? string.Empty : name,
                EmployeeId = ""
            };
            var actual = JsonSerializer.Deserialize<CreateEmployeeResponse>(_restResponse.Content);
            var employeeId = actual.Employee.EmployeeId;
            
            Assert.IsNotNull(employeeId, "Employee Id");
            StringAssert.Matches(employeeId.ToString(), new Regex("^\\d{1,3}$"));
            actual.Should().BeEquivalentTo(expectedEmployee, options => options
                .Excluding(e => e.EmployeeId));

        }
    }
}