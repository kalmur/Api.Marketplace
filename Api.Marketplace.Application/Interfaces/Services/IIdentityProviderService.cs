using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Models;
using Auth0.ManagementApi.Paging;

namespace Api.Marketplace.Application.Interfaces.Services;

public interface IIdentityProviderService
{
    /// <summary>
    ///     Create a user in the external identity provider's system.
    /// </summary>
    /// <param name="user">
    ///     The <see cref="CreateUserDto" /> containing the necessary user information.
    ///     Email is <b>required</b>.
    /// </param>
    /// <returns>
    ///     An <see cref="Models.ApiResult" /> indicating whether the operation was a success, and containing
    ///     a <see cref="Auth0.ManagementApi.Models.User" /> with the external identity provider's identifier for the user.
    /// </returns>
    Task<ApiResult<Models.User>> CreateUserAsync(CreateUserDto user);

    /// <summary>
    ///     Update a user in the external identity provider's system.
    /// </summary>
    /// <param name="identityProviderId">The ID used by the external identity provider</param>
    /// <param name="user">The <see cref="UpdateUserDto" /> containing the fields to update.</param>
    /// <returns>
    ///     An <see cref="ApiResult" /> indicating whether the operation was a success,
    ///     and containing a <see cref="Auth0.ManagementApi.Models.User" /> with the updated fields.
    /// </returns>
    Task<ApiResult<Models.User>> UpdateUserAsync(string identityProviderId, UpdateUserDto user);

    /// <summary>
    ///     Get a user from the external identity provider's system.
    /// </summary>
    /// <param name="providerId">The external identity provider's identifier for the user.</param>
    /// <returns>
    ///     An <see cref="ApiResult" /> indicating whether the operation was a success, and containing
    ///     a <see cref="Auth0.ManagementApi.Models.User" /> with the external identity provider's identifier for the user.
    /// </returns>
    Task<ApiResult<Models.User>> GetUserAsync(string providerId);

    /// <summary>
    ///     Get a user from the external identity provider's system.
    /// </summary>
    /// <param name="email"> The user's e-mail address that is registered with the identity provider.</param>
    /// <returns>
    ///     An <see cref="ApiResult" /> indicating whether the operation was a success, and containing
    ///     a read-only list of <see cref="User" /> with the external identity provider's identifier for the user.
    /// </returns>
    Task<ApiResult<IReadOnlyList<Models.User>>> GetUserByEmail(string email);
}
