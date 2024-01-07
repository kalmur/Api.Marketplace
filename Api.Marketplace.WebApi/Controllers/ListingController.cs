﻿using Api.Marketplace.Application.Workflows.Listing.CreateListing;
using Api.Marketplace.Application.Workflows.Listing.DeleteListing;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly ILogger<CityController> _logger;
    private readonly IMediator _mediator;

    public ListingController(
        ILogger<CityController> logger, 
        IMediator mediator
    )
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponseDto))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingDto request)
    {
        var result = await _mediator.Send(new CreateListingRequest(
            request.UserId, request.CityId, request.SellLease, request.Name, request.Category, 
            request.Description, request.Price, request.Address, request.PostCode));

        _logger.LogInformation("Listing created.");

        return Created(
            "api/listing",
            result.ListingId);
    }

    [HttpDelete]
    [Route("{listingId}")]
    public async Task<IActionResult> DeleteListing(int listingId)
    {
        await _mediator.Publish(new DeleteListingNotification(listingId));

        return NoContent();
    }
}
