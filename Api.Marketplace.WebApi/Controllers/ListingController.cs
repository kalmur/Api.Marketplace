using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Listing.CreateListing;
using Api.Marketplace.Application.Workflows.Listing.DeleteListing;
using Api.Marketplace.Application.Workflows.Listing.GetListingByType;
using Api.Marketplace.Application.Workflows.Listing.GetListingsById;
using Api.Marketplace.Application.Workflows.Listing.UpdateListing;
using Api.Marketplace.Domain.Results.Errors;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpResponse _httpResponse;

    public ListingController(
        IMediator mediator, 
        IHttpResponse httpResponse
    )
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponseDto))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingDto request)
    {
        var result = await _mediator.Send(
            new CreateListingRequest(
                request.UserId, request.CityId, request.SellLease, request.Name, request.Category, 
                request.Description, request.Price, request.Address, request.PostCode)
        );

        return Created(
            "api/listing",
            result.ListingId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateListing([FromBody]UpdateListingDto dto)
    {
        var response = await _mediator.Send(new UpdateListingRequest(dto.ListingId, dto.SellLease, dto.Name, dto.Category, dto.Description, dto.Price, dto.Address, dto.PostCode, dto.AvailableFrom));

        if (response.HasErrored)
        {
            return response.Error.Type switch
            {
                ErrorType.NotFound => _httpResponse.NotFound(),
                _ => _httpResponse.InternalServerError()
            };
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{listingId}")]
    public async Task<IActionResult> DeleteListing(int listingId)
    {
        await _mediator.Publish(new DeleteListingNotification(listingId));

        return NoContent();
    }

    [HttpGet]
    [Route("type/{sellRent}")]
    public async Task<IActionResult> GetListingByType([FromRoute] int sellRent)
    {
        var listings = await _mediator.Send(new GetListingByTypeRequest(sellRent));

        if (listings is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        return Ok(listings);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetListingById([FromRoute] int id)
    {
        var listings = await _mediator.Send(new GetListingByIdRequest(id));

        if (listings is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        return Ok(listings);
    }
}
