using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Reviews.CreateReview
{
    public class CreateReviewHandler : INotificationHandler<CreateReviewNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateReviewNotification> _logger;

        public CreateReviewHandler(IApplicationDbContext context, ILogger<CreateReviewNotification> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(CreateReviewNotification notification, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                ListingId = notification.ListingId,
                UserId = notification.UserId,
                Rating = notification.Rating,
                Comment = notification.Comment
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Review created.");
        }
    }
}
