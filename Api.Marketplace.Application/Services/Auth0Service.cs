using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Models;
using Api.Marketplace.Application.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Api.Marketplace.Application.Services;

public class Auth0Service : IIdentityProviderService
{
    private readonly ILogger<Auth0Service> _logger;
    private readonly IAuth0QueryBuilder _queryBuilder;
    private readonly IHttpClientFactory _httpClient;
    private readonly Auth0Options _options;

    public Auth0Service(
        ILogger<Auth0Service> logger, 
        IAuth0QueryBuilder queryBuilder, 
        IHttpClientFactory httpClient, 
        IOptions<Auth0Options> options
    )
    {
        _logger = logger;
        _queryBuilder = queryBuilder;
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<AccessTokenResponse> GetAccessTokenAsync(CancellationToken token = default)
    {
        var client = _httpClient.CreateClient(ClientNames.Authentication);

        var body = new Dictionary<string, string>
        {
            { "client_id", _options.ClientId! },
            { "client_secret", _options.ClientSecret! },
            { "audience", _options.Audience! },
            { "grant_type", "client_credentials" }
        };

        var jsonBody = JsonConvert.SerializeObject(body);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync($"{_options.AuthenticationEndpoint}", content, token);

        var responseContent = await response.Content.ReadAsStringAsync(token);
        var tokenObject = JsonConvert.DeserializeObject<AccessTokenResponse>(responseContent);

        if (response.IsSuccessStatusCode && tokenObject is not null)
        {
            _logger.LogInformation("Successfully retrieved the AccessToken");
            return tokenObject;
        }

        return new AccessTokenResponse();
    }

    public async Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(IReadOnlyCollection<string> userIds, CancellationToken token = default)
    {
        var client = _httpClient.CreateClient(ClientNames.Auth0);

        var query = _queryBuilder.GenerateQueryString(userIds);

        var response = await client.GetAsync($"{_options.GetUsersEndpoint}?{query}", token);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<List<Auth0User>>(content)!;
        }

        return new List<Auth0User>();
    }
}
