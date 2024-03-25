using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class UpdateListingDto
    {
        [JsonPropertyName(nameof(ListingId))]
        public int ListingId { get; set; }

        [JsonPropertyName(nameof(SellLease))]
        public int SellLease { get; set; }

        [JsonPropertyName(nameof(Name))]
        public string Name { get; set; }

        [JsonPropertyName(nameof(Category))]
        public string Category { get; set; }

        [JsonPropertyName(nameof(Description))]
        public string? Description { get; set; }

        [JsonPropertyName(nameof(Price))]
        public int Price { get; set; }

        [JsonPropertyName(nameof(Address))]
        public string Address { get; set; }

        [JsonPropertyName(nameof(PostCode))]
        public string PostCode { get; set; }

        [JsonPropertyName(nameof(AvailableFrom))]
        public DateTime? AvailableFrom { get; set; } = DateTime.Now;
    }
}
