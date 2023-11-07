using Api.Marketplace.Application.Workflows.City.CreateCity;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ILogger<CityController> _logger;
    private readonly IMediator _mediator;

    public CityController(ILogger<CityController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCityResponseDto))]
    public async Task<IActionResult> CreateCityAsync([FromBody] CreateCityRequest request)
    {
        var city = await _mediator.Send(
            new CreateCityRequest(
                request.Name,
                request.Country));

        _logger.LogInformation("City created.");

        return Created(
            "api/city", 
            city.CityId);
    }
}
