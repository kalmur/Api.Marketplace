using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.Models;

public class AccessTokenResponse
{
    [JsonPropertyName("id_token")]
    public string IdToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}
