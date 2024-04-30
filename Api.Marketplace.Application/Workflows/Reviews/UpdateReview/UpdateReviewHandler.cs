using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.Reviews.UpdateReview
{
    public class UpdateReviewHandler : INotificationHandler<UpdateReviewNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UpdateReviewHandler> _logger;

        public UpdateReviewHandler(IApplicationDbContext context, ILogger<UpdateReviewHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(UpdateReviewNotification notification, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstAsync(x => x.ReviewId == notification.ReviewId, cancellationToken);

            review.Rating = notification.Rating;
            review.Comment = notification.Comment;

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Review with ID: {reviewId} has been updated", notification.ReviewId);
        }
    }
}
