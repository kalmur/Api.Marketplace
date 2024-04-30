using Api.Marketplace.Application.DTOs;
using Api.Marketplace.Application.Workflows.Photos.CreatePhoto;
using Api.Marketplace.Application.Workflows.Photos.UpdatePhoto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PostPhoto([FromBody] PhotoDto dto)
        {
            var notification = new CreatePhotoNotification(dto.ListingId, dto.Url, dto.IsPrimary);
            
            await _mediator.Publish(notification);

            return NoContent();
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePhoto([FromBody] PhotoDto dto)
        {
            var notification = new UpdatePhotoNotification(dto.PhotoId, dto.ListingId, dto.Url, dto.IsPrimary);

            await _mediator.Publish(notification);

            return NoContent();
        }
    }
}
