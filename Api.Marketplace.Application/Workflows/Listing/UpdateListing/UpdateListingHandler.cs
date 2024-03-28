using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Application.Workflows.Listing.GetListingsById;
using Api.Marketplace.Domain.Results.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Listing.UpdateListing
{
    public class UpdateListingHandler : IRequestHandler<UpdateListingRequest, UpdateListingResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetListingByIdHandler> _logger;

        public UpdateListingHandler
        (
            IApplicationDbContext context, 
            ILogger<GetListingByIdHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UpdateListingResponse> Handle(UpdateListingRequest request, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings.FirstAsync(x => x.ListingId == request.ListingId, cancellationToken);

            if (listing is null)
            {
                _logger.LogInformation("Listing with ID: {listingId} not found", request.ListingId);

                return new UpdateListingResponse
                (
                    error: new DatabaseError($"Listing {request.ListingId} not found")
                );
            }

            listing.SellLease = request.SellLease;
            listing.Name = request.Name;
            listing.Category = request.Category;
            listing.Description = request.Description;
            listing.Price = request.Price;
            listing.Address = request.Address;
            listing.PostCode = request.PostCode;
            listing.AvailableFrom = request.AvailableFrom;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateListingResponse();
        }
    }
}
