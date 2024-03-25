using System.Text.Json.Serialization;
using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Listing.GetListingByType
{
    public class GetListingByTypeResponse
    {
        [JsonPropertyName(nameof(Listings))]
        public IReadOnlyCollection<ListingDto>? Listings { get; set; }

        public GetListingByTypeResponse(IReadOnlyCollection<ListingDto>? listings)
        {
            Listings = listings;
        }
    }
}
