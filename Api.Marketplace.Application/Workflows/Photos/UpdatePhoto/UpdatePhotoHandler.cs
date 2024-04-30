using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Photos.UpdatePhoto
{
    public class UpdatePhotoHandler : INotificationHandler<UpdatePhotoNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UpdatePhotoHandler> _logger;

        public UpdatePhotoHandler(IApplicationDbContext context, ILogger<UpdatePhotoHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(UpdatePhotoNotification notification, CancellationToken cancellationToken)
        {
            var photo = await _context.Photos.FirstAsync(x => 
                x.PhotoId == notification.PhotoId & 
                x.ListingId == notification.ListingId, 
                cancellationToken);

            photo.Url = notification.Url;
            photo.IsPrimary = notification.IsPrimary;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
