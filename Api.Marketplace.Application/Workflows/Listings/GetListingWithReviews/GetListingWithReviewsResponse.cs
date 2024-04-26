using Api.Marketplace.Application.DTOs;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingWithReviews
{
    public class GetListingWithReviewsResponse
    {
        public GetListingWithReviewsResponse(ListingAndReviewDto? listingAndReview)
        {
            ListingAndReview = listingAndReview;
        }

        public ListingAndReviewDto? ListingAndReview { get; set; }
    }
}
