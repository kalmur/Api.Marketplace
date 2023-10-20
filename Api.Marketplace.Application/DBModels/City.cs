namespace Api.Marketplace.Application.DBModels;

public class City : AuditableEntity
{
    public string Name { get; set; }

    public string Country { get; set; }

    public virtual Listing Listings { get; set; }
}
