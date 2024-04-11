using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingsById
{
    public class GetListingByIdRequest : IRequest<GetListingByIdResponse>
    {
        public int Id { get; }

        public GetListingByIdRequest(int id)
        {
            Id = id;
        }
    }
}
