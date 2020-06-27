using System.Text.Json.Serialization;

namespace DomainObjects
{
    public class ReadEmployee : BaseEmployee
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        public ReadEmployee(string name, string Age, string salary, string id, string profileImage) : base(name, Age, salary)
        {
            Id = id;
            ProfileImage = profileImage;
        }
    }
}