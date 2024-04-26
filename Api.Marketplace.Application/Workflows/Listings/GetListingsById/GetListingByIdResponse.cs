using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{
    public class GetListingByIdResponse
    {
        public ListingDto? Listing { get; set; }

        public GetListingByIdResponse(ListingDto? listing)
        {
            Listing = listing;
        }
    }
}
