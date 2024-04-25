using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Cities.GetCityById;

public class GetCityByIdResponse
{
    public GetCityByIdResponse(CityDto? city)
    {
        City = city;
    }

    public CityDto? City { get; set; }
}
