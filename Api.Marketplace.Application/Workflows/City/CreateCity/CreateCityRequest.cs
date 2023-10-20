using MediatR;

namespace Api.Marketplace.Application.Workflows.City.CreateCity;

public class CreateCityRequest : IRequest<CreateCityResponse>
{
    public CreateCityRequest(string name, string country)
    {
        Name = name;
        Country = country;
    }

    public string Name { get; }
    public string Country { get; }
}
