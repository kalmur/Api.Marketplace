namespace Api.Marketplace.Domain.Entities;

public class Listing : AuditableEntity
{
    public int ListingId { get; set; }
    public int UserId { get; set; }
    public int CityId { get; set; }
    public int SellLease { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public DateTime? AvailableFrom { get; set; }

    public virtual User User { get; set; }
    public virtual City City { get; set; }
    public virtual IReadOnlyCollection<Review> Reviews { get; set; }
}
