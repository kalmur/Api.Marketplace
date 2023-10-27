using System.Text.Json.Serialization;

namespace Api.Marketplace.WebApi.DTOs;

public class CreateListingDto
{
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }

    [JsonPropertyName("CityId")]
    public int CityId { get; set; }

    [JsonPropertyName("SellLease")]
    public int SellLease { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Category")]
    public string Category { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("Price")] 
    public decimal Price { get; set; }

    [JsonPropertyName("Address")]
    public string Address { get; set; }
    
    [JsonPropertyName("PostCode")]
    public string PostCode { get; set; }
    
    [JsonPropertyName("AvailableFrom")]
    public DateTime? AvailableFrom { get; set; }
}
