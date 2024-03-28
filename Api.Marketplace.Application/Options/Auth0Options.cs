namespace Api.Marketplace.Application.Options;

public class Auth0Options
{
    public const string SectionName = "Auth0";

    public string? Domain { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret  { get; set; }
    public string? Connection { get; set; }
}
