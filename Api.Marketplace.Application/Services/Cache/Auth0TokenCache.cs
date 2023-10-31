using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using ZiggyCreatures.Caching.Fusion;

namespace Api.Marketplace.Application.Services.Cache;

public class Auth0TokenCache : IAuth0TokenCache
{
    private static string Key(string audience) => $"{nameof(Auth0TokenCache)}-{audience}";
    private const double TokenExpiryBuffer = 0.01d;

    private readonly IFusionCache _cache;
    private readonly IIdentityProviderService _auth0Service;
    private readonly Auth0Options _options;

    public Auth0TokenCache(
        IFusionCache cache, 
        IIdentityProviderService auth0Service, 
        IOptions<Auth0Options> options)
    {
        _cache = cache;
        _auth0Service = auth0Service;
        _options = options.Value;
    }

    public async ValueTask<string> GetTokenAsync(CancellationToken token = default)
    {
        return (await _cache.GetOrSetAsync<string>(Key(_options!.Audience!), async (config, token) =>
        {
            var tokenResponse = await _auth0Service.GetAccessTokenAsync(token);

            var accessToken = tokenResponse.AccessToken;

            var computedExpiry = Math.Ceiling(tokenResponse.ExpiresIn - tokenResponse.ExpiresIn * TokenExpiryBuffer);

            var expiry = TimeSpan.FromSeconds(computedExpiry);

            config.Options.SetDuration(expiry);
            config.Options.SetEagerRefresh(0.95f);

            return accessToken;
        }, token: token))!;
    }
}

