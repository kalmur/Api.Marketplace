using System.Text.Json.Serialization;

namespace Api.Marketplace.WebApi.DTOs;

public class CreateUserResponseDto
{
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }
}
