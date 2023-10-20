namespace Api.Marketplace.Application.Workflows.Listing.CreateListing;

public class CreateListingResponse
{
    public CreateListingResponse(int listingId)
    {
        ListingId = listingId;
    }

    public int ListingId { get; set; }
}
