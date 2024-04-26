using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Cities.GetCityById;
using Api.Marketplace.Application.Workflows.Listings.CreateListing;
using Api.Marketplace.Application.Workflows.Listings.DeleteListing;
using Api.Marketplace.Application.Workflows.Listings.GetListingByExternalProviderId;
using Api.Marketplace.Application.Workflows.Listings.GetListingByType;
using Api.Marketplace.Application.Workflows.Listings.GetListingsById;
using Api.Marketplace.Application.Workflows.Listings.GetListingWithReviews;
using Api.Marketplace.Application.Workflows.Listings.UpdateListing;
using Api.Marketplace.Domain.Results.Errors;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Extensions;
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
    private readonly ILogger<ListingsController> _logger;

    public ListingsController
    (
        IMediator mediator, 
        IHttpResponse httpResponse,
        ILogger<ListingsController> logger
    )
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponseDto))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingDto dto)
    {
        var request = new CreateListingRequest(
            dto.UserId, dto.CityId, dto.SellLease, dto.Name, dto.Category,
            dto.Description, dto.Price, dto.Address, dto.PostCode);

        var result = await _mediator.Send(request);

        return Created(
            "api/listing",
            result.ListingId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateListing([FromBody]UpdateListingDto dto)
    {
        var request = new UpdateListingRequest(
            dto.ListingId, dto.SellLease, dto.Name, dto.Category, dto.Description, 
            dto.Price, dto.Address, dto.PostCode, dto.AvailableFrom);

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
        var request = new GetListingByTypeRequest(sellRent);

        var listings = await _mediator.Send(request);

        if (listings is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        return Ok(listings);
    }

    [HttpGet]
    [Route("{listingId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingAndCityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingById([FromRoute] int listingId)
    {
        var request = new GetListingByIdRequest(listingId);

        var response = await _mediator.Send(request);

        if (response is null)
        {
            return _httpResponse.NotFound("No listings found");
        }

        var cityId = response!.Listing!.CityId;
        var city = await _mediator.Send(new GetCityByIdRequest(cityId));

        if (city is null)
        {
            _logger.LogInformation("City with ID: {cityId} not found", cityId);
        }

        var listingAndCity = response.Listing.ToDto(city.City);
        return Ok(listingAndCity);
    }

    [HttpGet]
    [Route("user/{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetListingByTypeResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingByUser([FromRoute] string externalProviderId)
    {
        var request = new GetListingByExternalProviderIdRequest(externalProviderId);

        var response = await _mediator.Send(request);

        if (response is null)
        {
            return _httpResponse.NotFound($"No listings found for user: {externalProviderId}");
        }

        var listings = response.Listings;
        return Ok(listings);
    }

    [HttpGet]
    [Route("{listingId}/reviews")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingAndReviewDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingWithReviews([FromRoute] int listingId)
    {
        var request = new GetListingWithReviewsRequest(listingId);

        var response = await _mediator.Send(request);

        if (response is null)
        {
            return _httpResponse.NotFound($"No listings found");
        }

        return Ok(response.ListingAndReview);
    }
}
