using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class ListingDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int SellLease { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        [JsonIgnore]
        public int CityId { get; set; }
    }
}
