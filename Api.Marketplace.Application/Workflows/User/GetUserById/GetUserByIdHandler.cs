using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Workflows.User.GetUserById;

public class GetUserByIdHandler 
    : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IApplicationDbContext _context;

    public GetUserByIdHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.UserId == request.UserId,
                cancellationToken);

        return user is not null ? new GetUserByIdResponse(user.Username) : new GetUserByIdResponse(null!);
    }
}
