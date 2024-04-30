using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Listings.CreateListing;
using Api.Marketplace.Application.Workflows.Listings.DeleteListing;
using Api.Marketplace.Application.Workflows.Listings.GetListingByExternalProviderId;
using Api.Marketplace.Application.Workflows.Listings.GetListingByType;
using Api.Marketplace.Application.Workflows.Listings.GetListingsById;
using Api.Marketplace.Application.Workflows.Listings.UpdateListing;
using Api.Marketplace.Domain.Results.Errors;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpResponse _httpResponse;

    public ListingsController(IMediator mediator, IHttpResponse httpResponse)
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponseDto))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingDto dto)
    {
        var request = new CreateListingRequest(dto.UserId, dto.CityId, dto.SellLease, 
            dto.Name, dto.Category, dto.Description, dto.Price, dto.Address, dto.PostCode);

        var response = await _mediator.Send(request);

        return Created("api/listing", response.ListingId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateListing([FromBody]UpdateListingDto dto)
    {
        var request = new UpdateListingRequest(dto.ListingId, dto.SellLease, dto.Name, 
            dto.Category, dto.Description, dto.Price, dto.Address, dto.PostCode, dto.AvailableFrom);

        var response = await _mediator.Send(request);

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
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> DeleteListing(int listingId)
    {
        await _mediator.Publish(new DeleteListingNotification(listingId));

        return NoContent();
    }

    [HttpGet]
    [Route("type/{sellRent}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetListingByTypeResponse))]
    public async Task<IActionResult> GetListingByType([FromRoute] int sellRent)
    {
        var response = await _mediator.Send(new GetListingByTypeRequest(sellRent));

        if (response is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{listingId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingAndCityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingById([FromRoute] int listingId)
    {
        var response = await _mediator.Send(new GetListingByIdRequest(listingId));

        if (response is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("user/{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetListingByTypeResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingByUser([FromRoute] string externalProviderId)
    {
        var response = await _mediator.Send(new GetListingByExternalProviderIdRequest(externalProviderId));

        if (response is null)
        {
            return _httpResponse.NotFound($"No listings found for user: {externalProviderId}");
        }

        return Ok(response.Listings);
    }
}
