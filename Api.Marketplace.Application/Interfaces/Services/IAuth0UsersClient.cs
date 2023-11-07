using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

namespace Api.Marketplace.Application.Interfaces.Services;

public interface IAuth0UsersClient
{
    Task<User> CreateAsync(UserCreateRequest request);
    Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination);
    Task<User> UpdateAsync(string id, UserUpdateRequest request);
    Task<User> GetAsync(string id, string fields = null, bool includeFields = true);
    Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null);
}
