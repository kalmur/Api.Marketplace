using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class ListingDto
    {
        [JsonPropertyName(nameof(Id))]
        public int Id { get; set; }

        [JsonPropertyName(nameof(SellLease))]
        public int SellLease { get; set; }

        [JsonPropertyName(nameof(Name))]
        public string Name { get; set; }

        [JsonPropertyName(nameof(Category))]
        public string Category { get; set; }

        [JsonPropertyName(nameof(Price))]
        public int Price { get; set; }

        //public string City { get; set; }
        //public string Country { get; set; }
    }
}
