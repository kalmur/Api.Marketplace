namespace Api.Marketplace.Application.DBModels;

public class City : AuditableEntity
{
    public City(string name, string country)
    {
        Name = name;
        Country = country;
        Listings = new List<Listing>();
    }

    public int CityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public virtual ICollection<Listing> Listings { get; set; }
}
