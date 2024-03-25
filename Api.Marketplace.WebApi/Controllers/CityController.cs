using Api.Marketplace.Application.Workflows.City.CreateCity;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCityResponseDto))]
    public async Task<IActionResult> CreateCityAsync([FromBody] CreateCityRequest request)
    {
        var city = await _mediator.Send(
            new CreateCityRequest(
                request.Name,
                request.Country)
        );

        return Created(
            "api/city", 
            city.CityId);
    }
}
