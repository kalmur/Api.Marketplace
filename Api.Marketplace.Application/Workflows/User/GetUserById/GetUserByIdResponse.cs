using Api.Marketplace.Application.Models;

namespace Api.Marketplace.Application.Workflows.User.GetUserById;

public class GetUserByIdResponse
{
    public GetUserByIdResponse(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}
