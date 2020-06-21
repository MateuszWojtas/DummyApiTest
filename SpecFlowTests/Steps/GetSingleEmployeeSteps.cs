using DomainObjects;
using FluentAssertions;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "GetSingleEmployee")]
    public class GetSingleEmployeeSteps : BaseSteps
    {

        [Given(@"I have request prepared with employee id (.*)")]
        public void GivenIHaveValidRequestPreparedWithEmployeeId(string p0)
        {
            var id = p0 != "null" ? p0 : string.Empty;
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/employee/{p0}");
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Content-Type", "text/plain");
            _restRequest.AddHeader("Cookie", "PHPSESSID=7a8bb0856b7cd9fe1b7c083709d0fb7d");

        }


        [Then(@"Response should contain data (.*),(.*),(.*),(.*)")]
        public void ThenResponseShouldContainDataOfEmployeeWithId(string id, string name, string age, string salary)
        {
            var expected = new ReadSingleEmployee
            {
                Status = "success",
                Employee = new ReadEmployee
                {
                    Id = id,
                    EmployeeName = name,
                    EmployeeAge = age,
                    EmployeeSalary = salary,
                    ProfileImage = ""
                }
            };
            var actual = JsonSerializer.Deserialize<ReadSingleEmployee>(_restResponse.Content);

            actual.Should().BeEquivalentTo(expected);
        }

        [Then(@"Response should contain error No Record")]
        public void ThenResponseShouldContainError()
        {
            var expected = new ReadSingleEmployeeError
            {
                Status = "failed",
                Data = "Record does not found."
            };
            var actual = JsonSerializer.Deserialize<ReadSingleEmployeeError>(_restResponse.Content);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}