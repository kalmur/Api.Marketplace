using Api.Marketplace.Application.DTOs;
using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.UpdateListing
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

        public int ListingId { get; set; }
        public int SellLease { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public DateTime? AvailableFrom { get; set; } = DateTime.Now;
    }
}
