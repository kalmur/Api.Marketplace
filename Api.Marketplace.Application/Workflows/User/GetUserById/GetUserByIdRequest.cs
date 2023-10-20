using MediatR;

namespace Api.Marketplace.Application.Workflows.User.GetUserById;

public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public int UserId { get; }

    public GetUserByIdRequest(int userId)
    {
        UserId = userId;
    }
}
