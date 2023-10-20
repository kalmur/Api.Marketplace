using System.Text.Json.Serialization;

namespace Api.Marketplace.WebApi.DTOs;

public class CreateCityResponseDto
{
    [JsonPropertyName("CityId")]
    public int CityId { get; set; }
}
