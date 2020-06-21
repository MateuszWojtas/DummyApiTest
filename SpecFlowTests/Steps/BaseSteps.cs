using RestSharp;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    public class BaseSteps
    {
        protected IRestResponse _restResponse;
        protected IRestClient _restClient;
        protected RestRequest _restRequest;


        [When(@"Request is sent")]
        public void WhenISendGetRequest()
        {
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
