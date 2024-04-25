using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Listings.CreateListing;
using Api.Marketplace.Domain.Entities;

namespace Api.Marketplace.Application.Extensions
{
    public static class MapperExtensions
    {
        public static Listing ToListingEntity(this CreateListingRequest request)
        {
            return new Listing
            {
                UserId = request.UserId,
                CityId = request.CityId,
                SellLease = request.SellLease,
                Name = request.Name,
                Category = request.Category,
                Description = request.Description ?? string.Empty,
                Price = request.Price,
                Address = request.Address,
                PostCode = request.PostCode,
                AvailableFrom = request.AvailableFrom ?? DateTime.Now
            };
        }

        public static IReadOnlyCollection<ListingDto> ToDto(this IReadOnlyCollection<Listing> listings)
        {
            var dtos = new List<ListingDto>();

            foreach (var listing in listings)
            {
                dtos.Add(new ListingDto
                {
                    Id = listing.ListingId,
                    SellLease = listing.SellLease,
                    Name = listing.Name,
                    Category = listing.Category,
                    Price = listing.Price
                });
            }

            return dtos;
        }

        public static ListingDto ToDto(this Listing listing)
        {
            return new ListingDto
            {
                Id = listing.ListingId,
                SellLease = listing.SellLease,
                Name = listing.Name,
                Category = listing.Category,
                Price = listing.Price,
                CityId = listing.CityId
            };
        }

        public static IReadOnlyCollection<ListingDto> ToListDto(this IReadOnlyCollection<Listing> listings)
        {
            return listings.Select(listing => new ListingDto
            {
                Id = listing.ListingId,
                SellLease = listing.SellLease,
                Name = listing.Name,
                Category = listing.Category,
                Price = listing.Price,
                CityId = listing.CityId
            })
                .ToList();
        }

        public static CityDto ToDto(this City city)
        {
            return new CityDto
            {
                CityId = city.CityId,
                Country = city.Country,
                Name = city.Name
            };
        }
    }
}
