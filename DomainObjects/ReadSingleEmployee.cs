using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ReadSingleEmployee
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public ReadEmployee Employee { get; set; }
    }
}