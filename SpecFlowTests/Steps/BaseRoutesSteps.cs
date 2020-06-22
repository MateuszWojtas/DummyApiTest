using DomainObjects;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    [Scope(Feature = "BaseRoutes")]
    public class BaseRoutesSteps : BaseSteps
    {
        [Given(@"I have base page url with route (.*) and method (.*)")]
        public void GivenIHaveBasePageUrlWithRouteAndMethod(string route, RestSharp.Method method)
        {
            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1{route}");
            _restRequest = new RestRequest(method);
        }

        [Given(@"I Prapare (.*) that require session data without it")]
        public void GivenIPrepareRequestThatRequireSessionData(string route, RestSharp.Method method)
        {
            string singleread = $"/employee/1";
            string update = "/update";
            string delete = "/delete";
            string finalroute = "";


            _restClient = new RestClient($"http://dummy.restapiexample.com/api/v1");
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Cookie", "PHPSESSID=061aa161aefa9611b5fe5b4aaa1b10f0");
            _restRequest.AddParameter("text/plain", "", ParameterType.RequestBody);
        }

        [Then(@"Result should return error message: (.*)")]
        public void ThenResultShouldShowError(string errorMessage)
        {
            var expected = new RouteError()
            {
                Message = errorMessage
            };
            var actual = JsonSerializer.Deserialize<RouteError>(_restResponse.Content);
        }
    }
}
