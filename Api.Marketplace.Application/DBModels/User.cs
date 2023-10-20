namespace Api.Marketplace.Application.DBModels;

public class User 
{
    public User(string username)
    {
        Username = username;
        Listings = new List<Listing>();
    }

    public int UserId { get; set; }
    public string Username { get; set; }
    public virtual ICollection<Listing> Listings { get; set; }
}
