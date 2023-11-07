using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Models;
using Api.Marketplace.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IIdentityProviderService _identityService;

    public UserController(
        ILogger<UserController> logger,
        IIdentityProviderService identityService)
    {
        _logger = logger;
        _identityService = identityService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserResponseDto))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        return await CreateNewUser(createUserDto);
    }

    [HttpGet]
    [Route("{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuth0User(string providerId)
    {
        var response = _identityService.GetUserAsync(providerId).ConfigureAwait(false);
        return Ok(response);
    }

    private async Task<IActionResult> CreateNewUser(CreateUserDto user)
    {
        var identityProviderUser = await GetAuthUserOrCreate(user);

        if (!identityProviderUser.Succeeded)
            return StatusCode((int)identityProviderUser.StatusCode, identityProviderUser.Message);

        return Ok(identityProviderUser);
    }

    private async Task<ApiResult<User>> GetAuthUserOrCreate(CreateUserDto user)
    {
        ApiResult<User> identityProviderUser;
        var existingProviderUserResult =
            await _identityService.GetUserByEmail(user.Email).ConfigureAwait(false);

        if (existingProviderUserResult.Succeeded && existingProviderUserResult.Item.Any())
        {
            if (existingProviderUserResult.Item.Count > 1)
                return new ApiResult<User>
                {
                    Message = $"Multiple users found with the email address {user.Email}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Succeeded = false
                };

            identityProviderUser = new ApiResult<User>
            {
                StatusCode = existingProviderUserResult.StatusCode,
                Succeeded = true,
                Item = existingProviderUserResult.Item.First()
            };

            await UpdateUser(identityProviderUser);
        }
        else
        {
            var createUserResult = await _identityService.CreateUserAsync(user).ConfigureAwait(false);
            if (!createUserResult.Succeeded)
                return createUserResult;

            identityProviderUser = createUserResult;

            await UpdateUser(identityProviderUser);
        }

        return identityProviderUser;
    }

    private async Task<ApiResult<User>> UpdateUser(ApiResult<User> identityProviderUser)
    {
        var updateUser = new UpdateUserDto
        {
            FirstName = identityProviderUser.Item.FirstName,
            LastName = identityProviderUser.Item.LastName,
            Email = identityProviderUser.Item.Email,
            PhoneNumber = identityProviderUser.Item.PhoneNumber
        };

        return await _identityService.UpdateUserAsync(identityProviderUser.Item.ProviderSubjectId, updateUser)
            .ConfigureAwait(false);
    }
}
