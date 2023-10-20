using Api.Marketplace.Application.Interfaces;
using MediatR;

namespace Api.Marketplace.Application.Workflows.City.CreateCity;

public class CreateCityHandler 
    : IRequestHandler<CreateCityRequest, CreateCityResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateCityHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateCityResponse> Handle(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var city = new DBModels.City(request.Name, request.Country);

        _context.Cities.Add(city);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCityResponse(city.CityId);
    }
}
