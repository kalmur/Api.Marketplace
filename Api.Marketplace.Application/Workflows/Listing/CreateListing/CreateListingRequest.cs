using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.CreateListing;

public class CreateListingRequest : IRequest<CreateListingResponse>
{
    public CreateListingRequest(int sellLease, string name, string category, string? description, decimal price, string address, string postCode)
    {
        SellLease = sellLease;
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        Address = address;
        PostCode = postCode;
    }

    public int UserId { get; }
    public int CityId { get; }
    public int SellLease { get; }
    public string Name { get; }
    public string Category { get; }
    public string? Description { get; }
    public decimal Price { get; }
    public string Address { get; }
    public string PostCode { get; }
    public DateTime? AvailableFrom { get; }
}
