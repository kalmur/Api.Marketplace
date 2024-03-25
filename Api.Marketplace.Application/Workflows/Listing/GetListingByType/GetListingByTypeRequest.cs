using MediatR;

namespace Api.Marketplace.Application.Workflows.Listing.GetListingByType
{
    public class GetListingByTypeRequest : IRequest<GetListingByTypeResponse>
    {
        public int SellLease { get; set; }

        public GetListingByTypeRequest(int sellLease)
        {
            SellLease = sellLease;
        }
    }
}
