using Api.Marketplace.Application.Workflows.Reviews.CreateReview;
using Api.Marketplace.WebApi.DTOs;
using Api.Marketplace.WebApi.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpResponse _httpResponse;
    private readonly ILogger<ReviewsController> _logger;

    public ReviewsController(IMediator mediator, IHttpResponse httpResponse, ILogger<ReviewsController> logger)
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
        _logger = logger;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
    {
        var notification = new CreateReviewNotification(dto.UserId, dto.ListingId, dto.Rating, dto.Comment);

        await _mediator.Publish(notification);
        
        _logger.LogInformation("Review created");

        return NoContent();
    }
}
