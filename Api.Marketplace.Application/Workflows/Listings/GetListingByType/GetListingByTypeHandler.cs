using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingByType
{
    public class GetListingByTypeHandler : IRequestHandler<GetListingByTypeRequest, GetListingByTypeResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetListingByTypeHandler> _logger;

        public GetListingByTypeHandler(IApplicationDbContext context, ILogger<GetListingByTypeHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<GetListingByTypeResponse> Handle(GetListingByTypeRequest request, CancellationToken cancellationToken)
        {
            var listings = await _context.Listings
                .Where(x => x.SellLease == request.SellLease)
                .ToListAsync(cancellationToken);

            return listings.Any()
                ? new GetListingByTypeResponse(listings.ToDto())
                : new GetListingByTypeResponse(null);
        }
    }
}
