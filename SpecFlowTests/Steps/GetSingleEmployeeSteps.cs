using System;
using System.Text.Json;
using DomainObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "GetSingleEmployee")]
    public class GetSingleEmployeeSteps : BaseSteps
    {

        [Given(@"I have valid request prepared with employee id (.*)")]
        public void GivenIHaveValidRequestPreparedWithEmployeeId(int p0)
        {
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/employee/{p0}");
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Content-Type", "text/plain");
            _restRequest.AddHeader("Cookie", "PHPSESSID=7a8bb0856b7cd9fe1b7c083709d0fb7d");
            
        }


        [Then(@"Response should contain data of employee with id (.*)")]
        public void ThenResponseShouldContainDataOfEmployeeWithId(string p0)
        {
            string expectedJSONString = $"{{\"status\":\"success\",\"data\":{{\"id\":\"{p0}\",\"employee_name\":\"Tiger Nixon\",\"employee_salary\":\"320800\",\"employee_age\":\"61\",\"profile_image\":\"\"}}}}";
            var expected = JsonSerializer.Deserialize<ReadSingleEmployee>(expectedJSONString);
            var actual = JsonSerializer.Deserialize<ReadSingleEmployee>(_restResponse.Content);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
