using Api.Marketplace.Application.Workflows.City.CreateCity;
using Api.Marketplace.Application.Workflows.Listing.CreateListing;
using Api.Marketplace.Application.Workflows.User.CreateUser;
using Api.Marketplace.WebApi.DTOs;

namespace Api.Marketplace.WebApi.Extensions;

public static class MapperExtensions
{
    public static CreateCityResponseDto ToDto(
        this CreateCityResponse response)
    {
        return new CreateCityResponseDto
        {
            CityId = response.CityId
        };
    }

    public static CreateUserResponseDto ToDto(
        this CreateUserResponse response)
    {
        return new CreateUserResponseDto
        {
            UserId = response.UserId
        };
    }

    public static CreateListingResponseDto ToDto(
        this CreateListingResponse response)
    {
        return new CreateListingResponseDto
        {
            ListingId = response.ListingId
        };
    }
}
