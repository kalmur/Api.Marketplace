using System.Text.Json.Serialization;
using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.WebApi.DTOs
{
    public class ListingAndCityDto
    {
        [JsonPropertyName(nameof(Listing))]
        public ListingDto Listing { get; set; }

        [JsonPropertyName(nameof(City))]
        public CityDto City { get; set; }
    }
}
