using RestSharp;
using TechTalk.SpecFlow;
using TestUtils;

namespace SpecFlowTests.Steps
{
    public class BaseSteps
    {
        protected IRestResponse _restResponse;
        protected IRestClient _restClient;
        protected IRestRequest _restRequest;
        protected readonly RestHelper RestHelper = new RestHelper();


        [When(@"Request is sent")]
        public void WhenISendGetRequest()
        {
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}