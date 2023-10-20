namespace Api.Marketplace.Application.Models;

public class ListingModel
{
    public ListingModel(int listingId, int sellLease, string name, string category, string? description, decimal price, string address, string postCode, DateTime availableFrom)
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
    public decimal Price { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public DateTime AvailableFrom { get; set; }
}
