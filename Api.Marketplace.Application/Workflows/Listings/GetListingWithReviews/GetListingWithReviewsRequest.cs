using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingWithReviews
{
    public class GetListingWithReviewsRequest : IRequest<GetListingWithReviewsResponse>
    {
        public GetListingWithReviewsRequest(int listingId)
        {
            ListingId = listingId;
        }

        public int ListingId { get; set; }
    }
}
