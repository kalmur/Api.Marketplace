using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Domain.Entities;
using MediatR;

namespace Api.Marketplace.Application.Workflows.Reviews.CreateReview
{
    public class CreateReviewHandler : INotificationHandler<CreateReviewNotification>
    {
        private readonly IApplicationDbContext _context;

        public CreateReviewHandler(IApplicationDbContext context)
        {
            _context = context;
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
        }
    }
}
