using Api.Marketplace.Application.DTOs;
using Api.Marketplace.WebApi.DTOs;

namespace Api.Marketplace.WebApi.Extensions
{
    public static class MapperExtensions
    {
        public static ListingAndCityDto ToDto(this ListingDto listing, CityDto city)
        {
            return new ListingAndCityDto
            {
                Listing = new ListingDto
                {
                    Name = listing.Name,
                    SellLease = listing.SellLease,
                    Category = listing.Category,
                    Price = listing.Price
                },
                City = new CityDto
                {
                    Name = city.Name,
                    Country = city.Country
                }
            };
        }
    }
}
