using MediatR;

namespace Api.Marketplace.Application.Workflows.Cities.CreateCities;

public class CreateCitiesRequest : IRequest<CreateCitiesResponse>
{
    public CreateCitiesRequest(string name, string country)
    {
        Name = name;
        Country = country;
    }

    public string Name { get; }
    public string Country { get; }
}
