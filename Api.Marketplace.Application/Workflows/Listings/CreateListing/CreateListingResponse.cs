namespace Api.Marketplace.Application.Workflows.Listings.CreateListing;

public class CreateListingResponse
{
    public CreateListingResponse(int listingId)
    {
        ListingId = listingId;
    }

    public int ListingId { get; }
}
