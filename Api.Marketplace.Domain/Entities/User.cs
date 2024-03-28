namespace Api.Marketplace.Domain.Entities;

public class User 
{
    public int UserId { get; set; }
    public string ExternalProviderId { get; set; }

    public virtual IReadOnlyCollection<Listing> Listings { get; set; }
}
