using RestSharp;

namespace TestUtils
{
    public class RestHelper
    {
        private IRestResponse _restResponse;
        private IRestClient _restClient;
        private RestRequest _restRequest;

        public RestHelper()
        {
            _restClient = new RestClient("http://dummy.restapiexample.com/api/v1/employees");
        }


    }
}