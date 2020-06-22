using System.Linq;
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
        }
        public IRestResponse CreateDummyEmployee()
        {
            var jsonRaw = $"{{\"name\":\"Dummy Employee\",\"salary\":\"1000\",\"age\":\"35\"}}";
            _restClient = new RestClient("http://dummy.restapiexample.com/api/v1/create");
            _restRequest = new RestRequest("", Method.POST, DataFormat.Json);
            _restRequest.AddParameter("application/json", jsonRaw, ParameterType.RequestBody);

            return _restClient.Execute(_restRequest);
        }

        public IRestRequest PrepareCreateEmployeeRequest(string employeeName, string employeeSalary, string employeeAge)
        {
            var jsonRaw = $"{{\"name\":\"{employeeName}\",\"salary\":\"{employeeSalary}\",\"age\":\"{employeeAge}\"}}";
            var restRequest = new RestRequest("", Method.POST, DataFormat.Json);
            restRequest.AddParameter("application/json", jsonRaw, ParameterType.RequestBody);

            return restRequest;
        }

        public IRestRequest PrepareUpdateEmployeeRequest(string name, string salary, string age, out string json)
        {
            json = $"{{\"name\":\"{name}\",\"salary\":\"{salary}\",\"age\":\"{age}\"}}";
            RestRequest request = PrepareBaseUpdateEmployeRequest();
            
            return request;
        }

        public IRestRequest PrepareUpdateEmployeeRequest(string name, string salary, string age)
        {
            RestRequest request = PrepareBaseUpdateEmployeRequest();
            
            return request;
        }

        public string GetSessionId()
        {
            IRestClient cookieclient = new RestClient("http://dummy.restapiexample.com/employees");
            IRestRequest cookieRequest = new RestRequest(Method.GET);
            cookieRequest.AddParameter("text/plain", "", ParameterType.RequestBody);
            var cookies = cookieclient.Execute(cookieRequest).Cookies;
            var sessionId = cookies.SingleOrDefault(x => x.Name == "PHPSESSID").Value;
            return sessionId;
        }

        private RestRequest PrepareBaseUpdateEmployeRequest()
        {
            RestRequest request = new RestRequest("", Method.PUT);
            request.AddHeader("Content-Type", "text/plain");

            return request;
        }
    }
}