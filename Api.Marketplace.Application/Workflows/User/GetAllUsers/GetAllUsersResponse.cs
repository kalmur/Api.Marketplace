using Api.Marketplace.Application.Models;

namespace Api.Marketplace.Application.Workflows.User.GetAllUsers;

public class GetAllUsersResponse
{
    public GetAllUsersResponse(Auth0UserModel user)
    {
        User = user;
    }

    public Auth0UserModel User { get; set; }
}
