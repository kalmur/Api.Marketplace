using MediatR;

namespace Api.Marketplace.Application.Workflows.Reviews.UpdateReview
{
    public class UpdateReviewNotification : INotification
    {
        public UpdateReviewNotification(int reviewId, int rating, string comment)
        {
            ReviewId = reviewId;
            Rating = rating;
            Comment = comment;
        }

        public int ReviewId { get; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
