using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs;
public class CreateUserDto
{
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("LastName")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [JsonPropertyName("Email")]
    public string Email { get; set; }

    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; }
}
