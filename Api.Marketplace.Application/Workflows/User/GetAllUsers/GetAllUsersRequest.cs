using MediatR;

namespace Api.Marketplace.Application.Workflows.User.GetAllUsers;

public class GetAllUsersRequest : IRequest<GetAllUsersResponse>
{
    public GetAllUsersRequest(List<string> userIds)
    {
        UserIds = userIds;
    }

    public List<string> UserIds { get; set; }
}
