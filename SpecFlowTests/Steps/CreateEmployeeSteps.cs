using System;
using System.Text.Json;
using DomainObjects;
using FluentAssertions;
using Gherkin.Ast;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class CreateEmployeeSteps : BaseSteps
    {
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }
        public int EmployeeAge { get; set; }

        [Given(@"I have entered (.*) as a name of employee")]
        public void GivenIHaveEnteredMateuszAsANameOfEmployee(string p0)
        {
            EmployeeName = p0;
        }
        
        [Given(@"I have entered (.*) as salary")]
        public void GivenIHaveEnteredAsSalary(int p0)
        {
            EmployeeSalary = p0;
        }
        
        [Given(@"I have entered (.*) as  age")]
        public void GivenIHaveEnteredAsAge(int p0)
        {
            EmployeeAge = p0;
        }
        
        [Given(@"Request is prepared")]
        public void GivenRequestIsPrepared()
        {
            var jsonRaw = $"{{\"name\":\"{EmployeeName}\",\"salary\":\"{EmployeeSalary}\",\"age\":\"{EmployeeAge}\"}}";
            _restClient = new RestClient("http://dummy.restapiexample.com/api/v1/create");
            _restRequest = new RestRequest("" ,Method.POST, DataFormat.Json);
            _restRequest.AddParameter("application/json", jsonRaw, ParameterType.RequestBody);
        }
        
        [Then(@"Guest should be created with data - (.*),(.*),(.*)")]
        public void ThenGuestShouldBeCreatedWithData_Mateusz(string name, string salary, string age)
        {
            var expectedEmployee = new ModifyEmployee{EmployeeAge = age, EmployeeSalary = salary, EmployeeName = name};
            var actual = JsonSerializer.Deserialize<CreateEmployeeResponse>(_restResponse.Content);

            //actual.Should().BeEquivalentTo(expectedEmployee);
            Assert.AreEqual(expectedEmployee.EmployeeName, actual.Employee.EmployeeName, "Employee Name");
            Assert.AreEqual(expectedEmployee.EmployeeSalary, actual.Employee.EmployeeSalary, "Employee Salary");
            Assert.AreEqual(expectedEmployee.EmployeeAge, actual.Employee.EmployeeAge, "Employee Age");
            Assert.IsNotNull(actual.Employee.EmployeeId, "Employee Id");
        }
    }
}
