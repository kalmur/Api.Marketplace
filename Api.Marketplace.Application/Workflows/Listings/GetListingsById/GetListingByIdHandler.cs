﻿using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{

    public class GetListingByIdHandler : IRequestHandler<GetListingByIdRequest, GetListingByIdResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetListingByIdHandler> _logger;

        public GetListingByIdHandler(IApplicationDbContext context, ILogger<GetListingByIdHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GetListingByIdResponse> Handle(GetListingByIdRequest request, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings.FirstOrDefaultAsync(x => x.ListingId == request.Id, cancellationToken);

            return listing is not null 
                ? new GetListingByIdResponse(listing.ToDto()) 
                : new GetListingByIdResponse(null);
        }
    }
}
