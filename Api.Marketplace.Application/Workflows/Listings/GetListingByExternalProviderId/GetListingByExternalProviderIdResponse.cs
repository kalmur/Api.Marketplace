using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingByExternalProviderId
{
    public class GetListingByExternalProviderIdResponse
    {
        public GetListingByExternalProviderIdResponse(IReadOnlyCollection<ListingDto?> listings)
        {
            Listings = listings;
        }

        public IReadOnlyCollection<ListingDto?> Listings { get; set; }
    }
}
