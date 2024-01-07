using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.DeleteListing;

public class DeleteListingNotification : INotification
{
    public DeleteListingNotification(int listingId)
    {
        ListingId = listingId;
    }

    public int ListingId { get; }
}
