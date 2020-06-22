using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class DeleteEmployee
    {
        [JsonPropertyName("status")] 
        public string Status { get; set; }
        
        [JsonPropertyName("message")] 
        public string Message { get; set; }
    }
}
