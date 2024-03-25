namespace Api.Marketplace.Application.Entities;

public class City : AuditableEntity
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public virtual ICollection<Listing> Listings { get; set; }
}
