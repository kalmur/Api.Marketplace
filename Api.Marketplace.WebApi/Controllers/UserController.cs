using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Workflows.User.CreateUser;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Api.Marketplace.Domain.Models;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IIdentityProviderService _identityService;
    private readonly IMediator _mediator;

    public UserController(IIdentityProviderService identityService, IMediator mediator)
    {
        _identityService = identityService;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserResponseDto))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var result = await GetAuthUserOrCreate(createUserDto);

        await _mediator.Publish(new CreateUserInDbNotification(result.Item.ProviderSubjectId));

        return !result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    [HttpGet]
    [Route("{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuth0User(string externalProviderId)
    {
        var result = await _identityService.GetUserAsync(externalProviderId);

        return !result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    [HttpPut]
    [Route("{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuth0User(
        string externalProviderId, 
        [FromBody] UpdateUserDto user
    )
    {
        var result = await _identityService.UpdateUserAsync(externalProviderId, new UpdateUserDto
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
        });

        return !result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    private async Task<ApiResult<UserModel>> GetAuthUserOrCreate(CreateUserDto user)
    {
        ApiResult<UserModel> identityProviderUser;

        var result = await _identityService.GetUserByEmail(user.Email).ConfigureAwait(false);

        if (result.Succeeded && result.Item.Any())
        {
            if (result.Item.Count > 1)
                return new ApiResult<UserModel>
                {
                    Message = $"Multiple users found with the email address {user.Email}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Succeeded = false
                };

            identityProviderUser = new ApiResult<UserModel>
            {
                StatusCode = result.StatusCode,
                Succeeded = true,
                Item = result.Item.First()
            };

            await UpdateUser(identityProviderUser);

        }
        else
        {
            var createUserResult = await _identityService.CreateUserAsync(user).ConfigureAwait(false);
            if (!createUserResult.Succeeded) return createUserResult;

            identityProviderUser = createUserResult;
            await UpdateUser(identityProviderUser);

            var externalProviderId = identityProviderUser.Item.ProviderSubjectId;
            await _mediator.Publish(new CreateUserInDbNotification(externalProviderId));
        }

        return identityProviderUser;
    }

    private async Task UpdateUser(ApiResult<UserModel> identityProviderUser)
    {
        var updateUser = new UpdateUserDto
        {
            FirstName = identityProviderUser.Item.FirstName,
            LastName = identityProviderUser.Item.LastName,
            Email = identityProviderUser.Item.Email,
            PhoneNumber = identityProviderUser.Item.PhoneNumber
        };

        await _identityService.UpdateUserAsync(identityProviderUser.Item.ProviderSubjectId, updateUser)
            .ConfigureAwait(false);
    }
}
