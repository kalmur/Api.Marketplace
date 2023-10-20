using Api.Marketplace.Application.Interfaces;
using MediatR;

namespace Api.Marketplace.Application.Workflows.User.CreateUser;

public class CreateUserHandler 
    : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateUserHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new DBModels.User(request.Username);

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(user.UserId);
    }
}
