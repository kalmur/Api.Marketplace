namespace Api.Marketplace.Application.Interfaces.Services;

public interface IAuth0QueryBuilder
{
    string GenerateQueryString(IReadOnlyCollection<string> userIds);
}
