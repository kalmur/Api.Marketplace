namespace Api.Marketplace.Domain.Entities;

public class City : AuditableEntity
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public virtual IReadOnlyCollection<Listing> Listings { get; set; }
}
