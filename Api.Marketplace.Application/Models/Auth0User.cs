using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.Models;

public class Auth0User
{
    public Auth0User(
        string externalProviderId,
        string firstName, 
        string lastName
    )
    {
        ExternalProviderId = externalProviderId;
        FirstName = firstName;
        LastName = lastName;
    }

    [JsonPropertyName("user_id")]
    public string ExternalProviderId { get; set; }
    
    [JsonPropertyName("given_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("family_name")]
    public string LastName { get; set; }
}
