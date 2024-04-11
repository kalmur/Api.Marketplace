using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.CreateListing;

public class CreateListingRequest : IRequest<CreateListingResponse>
{
    public CreateListingRequest(int userId, int cityId, int sellLease, string name, string category, string? description, int price, string address, string postCode)
    {
        UserId = userId;
        CityId = cityId;
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
    public int Price { get; }
    public string Address { get; }
    public string PostCode { get; }
    public DateTime? AvailableFrom { get; }
}
