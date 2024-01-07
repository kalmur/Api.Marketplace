using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Listing.DeleteListing;

public class DeleteListingHandler : INotificationHandler<DeleteListingNotification>
{
    private readonly ILogger<DeleteListingNotification> _logger;
    private readonly IApplicationDbContext _context;

    public DeleteListingHandler(
        ILogger<DeleteListingNotification> logger, 
        IApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task Handle(DeleteListingNotification notification, CancellationToken cancellationToken)
    {
        var listing = await _context.Listings.SingleOrDefaultAsync(x =>
                x.ListingId == notification.ListingId,
            cancellationToken);

        if (listing is not null)
        {
            _logger.LogInformation("Listing with ID: {id} is deleted.", listing.ListingId);

            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync(cancellationToken);
        }

        _logger.LogInformation("Listing could not be found.");
    }
}
