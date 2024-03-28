using Api.Marketplace.Domain.Results.Errors;

namespace Api.Marketplace.Application.Workflows.Listing.UpdateListing
{
    public class UpdateListingResponse
    {
        public UpdateListingResponse(Error error = default)
        {
            HasErrored = error is not null;
            Error = error;
        }

        public bool HasErrored { get; }
        public Error Error { get; }
    }
}
