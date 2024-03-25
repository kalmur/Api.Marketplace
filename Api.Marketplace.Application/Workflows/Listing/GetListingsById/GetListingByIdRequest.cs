using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.GetListingsById
{
    public class GetListingByIdRequest : IRequest<GetListingByIdResponse>
    {
        public int Id { get; set; }

        public GetListingByIdRequest(int id)
        {
            Id = id;
        }
    }
}
