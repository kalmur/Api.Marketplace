using Api.Marketplace.Application.DTOs;
using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.UpdateListing
{
    public class UpdateListingRequest : IRequest<UpdateListingResponse>
    {
        public UpdateListingRequest(int listingId, int sellLease, string name, string category, string? description, int price, string address, string postCode, DateTime? availableFrom)
        {
            ListingId = listingId;
            SellLease = sellLease;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Address = address;
            PostCode = postCode;
            AvailableFrom = availableFrom;
        }

        public int ListingId { get; }
        public int SellLease { get; }
        public string Name { get; }
        public string Category { get; }
        public string? Description { get; }
        public int Price { get; }
        public string Address { get; }
        public string PostCode { get; }
        public DateTime? AvailableFrom { get; } = DateTime.Now;
    }
}
