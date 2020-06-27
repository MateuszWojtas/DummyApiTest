using DomainObjects;
using FluentAssertions;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;
using Method = RestSharp.Method;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "DeleteEmployee")]
    public class DeleteEmployeeSteps : BaseSteps
    {
        private string _employeeId;
        [Given(@"Employee to be deleted exist")]
        public void EmployeeToBeDeletedExist()
        {
            //employee creation is not working properly on  this API so its not reliable.
            //var restHelper = new RestHelper();
            //var employeeTobedeleted = restHelper.CreateDummyEmployee();
            //_employeeId = JsonSerializer.Deserialize<CreateEmployeeResponse>(employeeTobedeleted.Content).Employee.EmployeeId.ToString();
            _employeeId = "14";
        }

        [Given(@"I prepared delete request")]
        public void GivenIPreparedDeleteRequest()
        {
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1/delete/{_employeeId}");
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Cookie", "PHPSESSID=061aa161aefa9611b5fe5b4aaa1b10f0");
            _restRequest.AddParameter("text/plain", "", ParameterType.RequestBody);
        }

        [Then(@"Delete confirmation message is returned")]
        public void ThenDeleteConfirmationMessageIsReturned()
        {
            var expected = new DeleteEmployee
            {
                Status = "success",
                Message = "successfully! deleted Records"
            };
            var actual = JsonSerializer.Deserialize<DeleteEmployee>(_restResponse.Content);
            actual.Should().BeEquivalentTo(expected);
        }

        [Then(@"Error message is returned")]
        public void ThenErrorMessageIsReturned()
        {
            var expected = new DeleteEmployee
            {
                Status = "failed",
                Message = "Error! Not able to delete record"
            };

            var actual = JsonSerializer.Deserialize<DeleteEmployee>(_restResponse.Content);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}