using Api.Marketplace.Application.Workflows.User.CreateUser;
using Api.Marketplace.Application.Workflows.User.GetUserById;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserResponseDto))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = await _mediator.Send(new CreateUserRequest(request.Username));

        _logger.LogInformation("User created.");

        return Created(
            "api/user",
            user.ToDto());
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById(int id)
    {
        var response = await _mediator.Send(new GetUserByIdRequest(id));

        return response is not null ? Ok(response) : NotFound();
    }
}
