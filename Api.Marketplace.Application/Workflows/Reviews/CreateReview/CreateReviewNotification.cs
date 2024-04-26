using MediatR;

namespace Api.Marketplace.Application.Workflows.Reviews.CreateReview
{
    public class CreateReviewNotification : INotification
    {
        public CreateReviewNotification(int userId, int listingId, int rating, string comment)
        {
            UserId = userId;
            ListingId = listingId;
            Rating = rating;
            Comment = comment;
        }

        public int UserId { get; }
        public int ListingId { get; }
        public int Rating { get; }
        public string Comment { get; }
    }
}
