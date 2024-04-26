using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingWithReviews;

public class GetListingWithReviewsHandler : IRequestHandler<GetListingWithReviewsRequest, GetListingWithReviewsResponse>
{
    private readonly IApplicationDbContext _context;

    public GetListingWithReviewsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetListingWithReviewsResponse> Handle(GetListingWithReviewsRequest request, CancellationToken cancellationToken)
    {
        var listing = await _context.Listings
            .Include(x => x.Reviews)
            .FirstAsync(x => x.ListingId == request.ListingId, cancellationToken);

        var listingAndReviewsDto = new ListingAndReviewDto
        {
            Listing = listing.ToDto(),
            Reviews = listing.Reviews.ToDto()
        };

        return new GetListingWithReviewsResponse(listingAndReviewsDto);
    }
}