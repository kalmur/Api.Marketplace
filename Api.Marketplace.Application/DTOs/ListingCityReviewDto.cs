using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class ListingCityReviewDto
    {
        [JsonPropertyName(nameof(Listing))]
        public ListingDto Listing { get; set; }

        [JsonPropertyName(nameof(City))]
        public CityDto City { get; set; }

        [JsonPropertyName(nameof(Reviews))]
        public IReadOnlyCollection<ReviewDto> Reviews { get; set; }   
    }
}
