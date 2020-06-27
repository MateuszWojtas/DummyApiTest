using System.Text.Json;
using DomainObjects;
using RestSharp;

namespace TestUtils
{
    public class RequestBuilder
    {
        private IRestResponse _restResponse;
        private IRestClient _restClient;
        private RestRequest _restRequest;

        public RequestBuilder()
        {
        }
        public IRestResponse CreateDummyEmployee()
        {
            var dummyEmployeeData = new BaseEmployee("Dummy Name", "45", "23000");
            var bodyMessage = JsonSerializer.Serialize(dummyEmployeeData);
            _restClient = new RestClient("http://dummy.restapiexample.com/api/v1/create");
            _restRequest = new RestRequest("", Method.POST, DataFormat.Json);
            _restRequest.AddParameter("application/json", bodyMessage, ParameterType.RequestBody);

            return _restClient.Execute(_restRequest);
        }

        public IRestRequest PrepareCreateEmployeeRequest(string employeeName, string employeeSalary, string employeeAge)
        {
            var employeeData = new BaseEmployee(employeeName, employeeAge, employeeSalary);
            var bodyMessage = JsonSerializer.Serialize(employeeData);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "text/plain");
            restRequest.AddHeader("Cookie", "ezCMPCCS=false; PHPSESSID=e4ce008d771fd8a20246f387df51227a");
            restRequest.AddParameter("text/plain", bodyMessage, ParameterType.RequestBody);

            return restRequest;
        }

        public IRestRequest PrepareUpdateEmployeeRequest(string name, string salary, string age, out string json)
        {
            var employeeData = new BaseEmployee(name, age, salary);
            json = JsonSerializer.Serialize(employeeData);
            RestRequest request = PrepareBaseUpdateEmployeRequest();
            
            return request;
        }

        public IRestRequest PrepareUpdateEmployeeRequest(string name, string salary, string age)
        {
            RestRequest request = PrepareBaseUpdateEmployeRequest();
            
            return request;
        }

        private RestRequest PrepareBaseUpdateEmployeRequest()
        {
            RestRequest request = new RestRequest("", Method.PUT);
            request.AddHeader("Content-Type", "text/plain");

            return request;
        }
    }
}