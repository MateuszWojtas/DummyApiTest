using RestSharp;
using System.Linq;

namespace TestUtils
{
    public class Utils
    {
        public string GetSessionId()
        {
            IRestClient cookieclient = new RestClient("http://dummy.restapiexample.com/employees");
            IRestRequest cookieRequest = new RestRequest(Method.GET);
            cookieRequest.AddParameter("text/plain", "", ParameterType.RequestBody);
            var cookies = cookieclient.Execute(cookieRequest).Cookies;
            var sessionId = cookies.SingleOrDefault(x => x.Name == "PHPSESSID").Value;
            return sessionId;
        }
    }
}
