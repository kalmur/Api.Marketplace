namespace Api.Marketplace.Application.Interfaces.Services;

public interface IAuth0TokenCache
{
    ValueTask<string> GetTokenAsync(CancellationToken token = default);
}
