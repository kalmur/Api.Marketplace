using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.DeleteListing;

public class DeleteListingNotification : INotification
{
    public DeleteListingNotification(int listingId)
    {
        ListingId = listingId;
    }

    public int ListingId { get; }
}
