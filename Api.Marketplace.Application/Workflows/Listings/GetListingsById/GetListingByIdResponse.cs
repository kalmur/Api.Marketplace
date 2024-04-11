using Api.Marketplace.Application.DTOs;
using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{
    public class GetListingByIdResponse
    {
        [JsonPropertyName(nameof(Listing))]
        public ListingDto? Listing { get; set; }

        public GetListingByIdResponse(ListingDto? listing)
        {
            Listing = listing;
        }
    }
}
