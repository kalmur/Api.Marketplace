using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingByExternalProviderId
{
    public class GetListingByExternalProviderIdHandler 
        : IRequestHandler<GetListingByExternalProviderIdRequest, GetListingByExternalProviderIdResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetListingByExternalProviderIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetListingByExternalProviderIdResponse> Handle(GetListingByExternalProviderIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ExternalProviderId == request.ExternalProviderId, cancellationToken);

            if (user is null)
            {
                return new GetListingByExternalProviderIdResponse(null);
            }

            var userId = user.UserId;

            var userListings = _context.Listings.Where(x => x.UserId == userId).ToList();

            if (!userListings.Any())
            {
                return new GetListingByExternalProviderIdResponse(null);
            }

            return new GetListingByExternalProviderIdResponse(userListings.ToListDto());
        }
    }
}
