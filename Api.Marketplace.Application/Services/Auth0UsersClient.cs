using Api.Marketplace.Application.Interfaces.Services;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

namespace Api.Marketplace.Application.Services;

public class Auth0UsersClient : IAuth0UsersClient
{
    private readonly IUsersClient _client;

    public Auth0UsersClient(IManagementApiClient userManagementClient)
    {
        _client = userManagementClient.Users;
    }

    public Task<User> CreateAsync(UserCreateRequest request)
    {
        return _client.CreateAsync(request);
    }

    public Task<IPagedList<User>> GetAllAsync(GetUsersRequest request,
        PaginationInfo pagination)
    {
        return _client.GetAllAsync(request, pagination);
    }

    public Task<User> UpdateAsync(string id, UserUpdateRequest request)
    {
        return _client.UpdateAsync(id, request);
    }

    public Task<User> GetAsync(string id, string fields = null,
        bool includeFields = true)
    {
        return _client.GetAsync(id, fields, includeFields);
    }

    public Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null,
        bool? includeFields = null)
    {
        return _client.GetUsersByEmailAsync(email, fields, includeFields);
    }
}
