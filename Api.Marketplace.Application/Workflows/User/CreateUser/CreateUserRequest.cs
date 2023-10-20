using MediatR;

namespace Api.Marketplace.Application.Workflows.User.CreateUser;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public CreateUserRequest(string username)
    {
        Username = username;
    }

    public string Username { get; }
}
