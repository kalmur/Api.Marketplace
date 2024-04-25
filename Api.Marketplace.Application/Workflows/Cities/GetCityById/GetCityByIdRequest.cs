using MediatR;

namespace Api.Marketplace.Application.Workflows.Cities.GetCityById;

public class GetCityByIdRequest : IRequest<GetCityByIdResponse>
{
    public GetCityByIdRequest(int cityId)
    {
        CityId = cityId;
    }

    public int CityId { get; set; }
}
