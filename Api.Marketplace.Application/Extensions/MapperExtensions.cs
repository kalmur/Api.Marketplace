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
                SellLease = request.SellLease,
                Name = request.Name,
                Category = request.Category,
                Price = request.Price,
                Description = request.Description ?? string.Empty,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                PostCode = request.PostCode
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
            }).ToList();
        }

        public static IReadOnlyCollection<ReviewDto> ToDto(this IReadOnlyCollection<Review> reviews)
        {
            return reviews.Select(review => 
                new ReviewDto
                {
                    Rating = review.Rating, 
                    Comment = review.Comment
                }).ToList();
        }
    }
}
