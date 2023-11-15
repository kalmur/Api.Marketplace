using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Options;
using Microsoft.Extensions.Options;

namespace Api.Marketplace.Application.Services;

public class Auth0QueryBuilder : IAuth0QueryBuilder
{
    private readonly Auth0Options _options;

    public Auth0QueryBuilder(IOptions<Auth0Options> options)
    {
        _options = options.Value;
    }

    public string GenerateQueryString(IReadOnlyCollection<string> userIds)
    {
        var query = GetUsersProfileQueryChunk(userIds);

        return _options.UsersQuery!
            .Replace("{FieldsToInclude}", _options.FieldsToInclude)
            .Replace("{IncludeFields}", _options.IncludeFields)
            .Replace("{Query}", query)
            .Replace("{SearchEngine}", _options.SearchEngine);
    }

    private static string GetUsersProfileQueryChunk(IEnumerable<string> userIds)
        => "user_id(\"" + string.Join("\"OR\"", userIds) + "\")";
}
