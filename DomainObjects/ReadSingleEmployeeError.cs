using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ReadSingleEmployeeError
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}