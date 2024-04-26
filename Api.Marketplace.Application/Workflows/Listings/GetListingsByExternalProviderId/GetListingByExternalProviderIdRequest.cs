using MediatR;

namespace Api.Marketplace.Application.Workflows.Listings.GetListingByExternalProviderId
{
    public class GetListingByExternalProviderIdRequest : IRequest<GetListingByExternalProviderIdResponse>
    {
        public GetListingByExternalProviderIdRequest(string externalProviderId)
        {
            ExternalProviderId = externalProviderId;
        }

        public string ExternalProviderId { get; }
    }
}
