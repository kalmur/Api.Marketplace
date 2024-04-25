using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class CityDto
    {
        [JsonIgnore]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
