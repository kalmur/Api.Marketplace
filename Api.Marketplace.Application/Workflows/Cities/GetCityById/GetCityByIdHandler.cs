using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Workflows.Cities.GetCityById
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdRequest, GetCityByIdResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetCityByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetCityByIdResponse> Handle(GetCityByIdRequest request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == request.CityId, cancellationToken);

            if (city is not null)
            {
                return new GetCityByIdResponse(city.ToDto());
            }

            return new GetCityByIdResponse(null);
        }
    }
}
