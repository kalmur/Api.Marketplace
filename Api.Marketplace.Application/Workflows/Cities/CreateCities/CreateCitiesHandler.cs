using Api.Marketplace.Application.Interfaces;
using MediatR;
using City = Api.Marketplace.Domain.Entities.City;

namespace Api.Marketplace.Application.Workflows.Cities.CreateCities;

public class CreateCitiesHandler : IRequestHandler<CreateCitiesRequest, CreateCitiesResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateCitiesHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateCitiesResponse> Handle(CreateCitiesRequest request, CancellationToken cancellationToken)
    {
        var city = new City
        {
            Name = request.Name,
            Country = request.Country
        };

        _context.Cities.Add(city);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCitiesResponse(city.CityId);
    }
}
