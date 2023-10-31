namespace Api.Marketplace.Application.Options;

public class Auth0Options
{
    public const string SectionName = "Auth0";

    public string? Domain { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret  { get; set; }
    public string? Audience { get; set; }
    public string? AuthenticationEndpoint { get; set; }
    public string? GetUsersEndpoint { get; set; }
    public string? UsersQuery { get; set; }
    public string? FieldsToInclude { get; set;}
    public string? IncludeFields { get; set;}
    public string? SearchEngine { get; set; }
}
