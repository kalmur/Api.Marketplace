namespace Api.Marketplace.Application.Workflows.City.CreateCity;

public class CreateCityResponse
{
    public CreateCityResponse(int cityId)
    {
        CityId = cityId;
    }

    public int CityId { get; }
}
