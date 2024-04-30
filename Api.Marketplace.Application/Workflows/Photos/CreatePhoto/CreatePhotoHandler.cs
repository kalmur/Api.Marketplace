using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Photos.CreatePhoto
{
    public class CreatePhotoHandler : INotificationHandler<CreatePhotoNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreatePhotoHandler> _logger;

        public CreatePhotoHandler(IApplicationDbContext context, ILogger<CreatePhotoHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task Handle(CreatePhotoNotification notification, CancellationToken cancellationToken)
        {
            var photo = new Photo
            {
                ListingId = notification.ListingId,
                Url = notification.Url,
                IsPrimary = notification.IsPrimary
            };

            _context.Photos.Add(photo);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Photo with ID: {photoId} created.", photo.PhotoId);
        }
    }
}
