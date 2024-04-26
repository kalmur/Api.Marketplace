using Api.Marketplace.Application.Workflows.Cities.CreateCities;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCityResponseDto))]
    public async Task<IActionResult> CreateCitiesAsync([FromBody] CreateCitiesRequest request)
    {
        var city = await _mediator.Send(
            new CreateCitiesRequest(
                request.Name,
                request.Country)
        );

        return Created("/api/cities", city.CityId);
    }
}
