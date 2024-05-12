using System.Text.Json.Serialization;

namespace Api.Marketplace.WebApi.DTOs;

public class CreateListingDto
{
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }

 

    [JsonPropertyName("SellLease")]
    public int SellLease { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Category")]
    public string Category { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("Price")] 
    public int Price { get; set; }

    [JsonPropertyName("Address")]
    public string Address { get; set; }

    [JsonPropertyName("City")]
    public string City { get; set; }

    [JsonPropertyName("Country")]
    public string Country { get; set; }

    [JsonPropertyName("PostCode")]
    public string PostCode { get; set; }
    
    [JsonPropertyName("AvailableFrom")]
    public DateTime? AvailableFrom { get; set; }
}
