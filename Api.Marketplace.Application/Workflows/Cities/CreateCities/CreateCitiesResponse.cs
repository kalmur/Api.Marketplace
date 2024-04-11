namespace Api.Marketplace.Application.Workflows.Cities.CreateCities;

public class CreateCitiesResponse
{
    public CreateCitiesResponse(int cityId)
    {
        CityId = cityId;
    }

    public int CityId { get; }
}
