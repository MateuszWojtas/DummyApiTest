using DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Text.Json;
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
        public void GivenIHaveEnteredMateuszAsANameOfEmployee(string p0)
        {
            EmployeeName = p0 == "null" ? null : p0;
        }

        [Given(@"I have entered (.*) as salary")]
        public void GivenIHaveEnteredAsSalary(string p0)
        {
            EmployeeSalary = p0 == "null" ? null : p0;
        }

        [Given(@"I have entered (.*) as  age")]
        public void GivenIHaveEnteredAsAge(string p0)
        {
            EmployeeAge = p0 == "null" ? null : p0;
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
                EmployeeName = name == "null" ? string.Empty : name
            };
            var actual = JsonSerializer.Deserialize<CreateEmployeeResponse>(_restResponse.Content);

            Assert.AreEqual(expectedEmployee.EmployeeName, actual.Employee.EmployeeName, "Employee Name");
            Assert.AreEqual(expectedEmployee.EmployeeSalary, actual.Employee.EmployeeSalary, "Employee Salary");
            Assert.AreEqual(expectedEmployee.EmployeeAge, actual.Employee.EmployeeAge, "Employee Age");
            Assert.IsNotNull(actual.Employee.EmployeeId, "Employee Id");
        }

        //not needed since there are no error cases at the moment
        //[Then(@"Error response is returned with message")]
        //public void ThenErrorIsReturned()
        //{
        //    var error = _restResponse.ErrorMessage;
        //    Console.WriteLine(_restResponse.Content);
        //}
    }
}