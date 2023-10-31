using Api.Marketplace.Application.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.User.GetAllUsers;

public class GetAllUsersHandler 
    : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly ILogger<GetAllUsersHandler> _logger;
    private readonly IIdentityProviderService _auth0Service;

    public GetAllUsersHandler(
        ILogger<GetAllUsersHandler> logger, 
        IIdentityProviderService auth0Service)
    {
        _logger = logger;
        _auth0Service = auth0Service;
    }


    public async Task<GetAllUsersResponse> Handle(
        GetAllUsersRequest request, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving all users from Auth0.");

        var users = await _auth0Service.GetUsersInformationAsync(request.UserIds, cancellationToken);

        return new GetAllUsersResponse();
    }
}
