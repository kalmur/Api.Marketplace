using Api.Marketplace.Application.Interfaces.Services;
using System.Net.Http.Headers;

namespace Api.Marketplace.Application.Services;

public class Auth0TokenHandler : DelegatingHandler
{
    public const string Scheme = "Bearer";
    public IAuth0TokenCache _cache;

    public Auth0TokenHandler(IAuth0TokenCache cache)
    {
        _cache = cache;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken ct)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue(Scheme, await _cache.GetTokenAsync(ct));
        return await base.SendAsync(request, ct);
    }
}
