using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Reviews.CreateReview;
using Api.Marketplace.Application.Workflows.Reviews.UpdateReview;
using Api.Marketplace.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
    {
        var notification = new CreateReviewNotification(dto.UserId, dto.ListingId, dto.Rating, dto.Comment);

        await _mediator.Publish(notification);
        
        return NoContent();
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDto dto)
    {
        var notification = new UpdateReviewNotification(dto.ReviewId, dto.Rating, dto.Comment);

        await _mediator.Publish(notification);

        return NoContent();
    }
}
