using Api.Marketplace.Application.Models;

namespace Api.Marketplace.Application.Interfaces.Services;

public interface IIdentityProviderService
{
    Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(IReadOnlyCollection<string> userIds, CancellationToken token = default);
    Task<AccessTokenResponse> GetAccessTokenAsync(CancellationToken token = default);
}
