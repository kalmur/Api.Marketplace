using Api.Marketplace.Application.Workflows.Listing.CreateListing;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly ILogger<CityController> _logger;
    private readonly IMediator _mediator;

    public ListingController(ILogger<CityController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponseDto))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingRequest request)
    {
        var listing = await _mediator.Send(new CreateListingRequest(
            request.SellLease, request.Name, request.Category, request.Description, request.Price, request.Address,
            request.PostCode));

        _logger.LogInformation("Listing created.");

        return Created(
            "api/listing",
            listing.ToDto());
    }
}
