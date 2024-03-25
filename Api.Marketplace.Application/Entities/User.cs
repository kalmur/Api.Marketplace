namespace Api.Marketplace.Application.Entities;

public class User 
{
    public int UserId { get; set; }
    public string ExternalProviderId { get; set; }

    public virtual ICollection<Listing> Listings { get; set; }
}
