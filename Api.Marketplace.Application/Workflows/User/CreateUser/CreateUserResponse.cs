namespace Api.Marketplace.Application.Workflows.User.CreateUser;

public class CreateUserResponse
{
    public CreateUserResponse(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
