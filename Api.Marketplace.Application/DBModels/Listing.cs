namespace Api.Marketplace.Application.DBModels;

public class Listing
{
    public int SellRent { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public string County { get; set; }
    public string Zip { get; set; }
    public DateTime AvailableFrom { get; set; }
    public string Description { get; set; }
    public DateTime PostedOn { get; set; } = DateTime.Now;

    public virtual City Cities { get; set; }
}
