namespace Api.Marketplace.Application.DBModels;

public class Listing : AuditableEntity
{
    private City? _city;
    private User? _user;

    public Listing(int sellLease, string name, string category, string? description, decimal price, string address, string postCode)
    {
        SellLease = sellLease;
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        Address = address;
        PostCode = postCode;
    }

    public int ListingId { get; set; }
    public int UserId { get; set; }
    public int CityId { get; set; }
    public int SellLease { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public DateTime? AvailableFrom { get; set; }

    public virtual User? User
    {
        get => _user ?? throw new ArgumentNullException(nameof(User));
        set => _user = value;
    }

    public virtual City? City
    {
        get => _city ?? throw new ArgumentNullException(nameof(City));
        set => _city = value;
    }
}
