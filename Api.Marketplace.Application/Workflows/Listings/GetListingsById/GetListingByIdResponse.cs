using System.Text.Json.Serialization;
using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{
    public class GetListingByIdResponse
    {
        [JsonPropertyName(nameof(Entry))]
        public ListingDto? Entry { get; set; }

        public GetListingByIdResponse(ListingDto? entry)
        {
            Entry = entry;
        }
    }
}
