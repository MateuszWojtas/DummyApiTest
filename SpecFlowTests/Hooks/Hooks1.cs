using System.Configuration;
using System.IO;
using System.Net;
using RestSharp;
using TechTalk.SpecFlow;
using TestUtils;

namespace SpecFlowTests.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            //IRestClient client = new RestClient("http://dummy.restapiexample.com/api/v1/employee/9");
            //IRestRequest request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //var sessionId = response.Cookies[0].Value;
            //client.CookieContainer.Add(new Cookie("SessionId", sessionId));
           
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: nothing at the moment
        }
    }
}
