using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.CreateListing;

public class CreateListingRequest : IRequest<CreateListingResponse>
{
    public CreateListingRequest(int userId, int sellLease, string name, string category, string? description, int price, string address, string city, string country, string postCode)
    {
        UserId = userId;
        SellLease = sellLease;
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        Address = address;
        City = city;
        Country = country;
        PostCode = postCode;
    }

    public int UserId { get; }
    public int SellLease { get; }
    public string Name { get; }
    public string Category { get; }
    public string? Description { get; }
    public int Price { get; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
}
