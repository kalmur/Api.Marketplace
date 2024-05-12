using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{

    public class GetListingByIdHandler : IRequestHandler<GetListingByIdRequest, GetListingByIdResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetListingByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetListingByIdResponse> Handle(GetListingByIdRequest request, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings
                .Include(x => x.City)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.ListingId == request.Id, cancellationToken);

            if (listing is null)
            {
                return new GetListingByIdResponse(null);
            }

            return new GetListingByIdResponse(listing.ToDto());
        }
    }
}
