using Api.Marketplace.Application.DTOs;
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
    public async Task<IActionResult> CreateCitiesAsync([FromBody] CityDto dto)
    {
        var request = new CreateCitiesRequest(dto.Name, dto.Country);

        var response = await _mediator.Send(request);

        return Created("/api/cities", response.CityId);
    }
}
