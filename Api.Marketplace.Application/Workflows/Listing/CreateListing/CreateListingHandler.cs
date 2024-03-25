using Api.Marketplace.Application.Entities;
using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.CreateListing;

public class CreateListingHandler 
    : IRequestHandler<CreateListingRequest, CreateListingResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateListingHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateListingResponse> Handle(CreateListingRequest request, CancellationToken cancellationToken)
    {
        var listing = request.ToListingEntity();
        
        _context.Listings.Add(listing);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateListingResponse(listing.ListingId);
    }
}
