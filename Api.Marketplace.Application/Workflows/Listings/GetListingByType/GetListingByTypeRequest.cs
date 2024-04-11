using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingByType
{
    public class GetListingByTypeRequest : IRequest<GetListingByTypeResponse>
    {
        public int SellLease { get; }

        public GetListingByTypeRequest(int sellLease)
        {
            SellLease = sellLease;
        }
    }
}
