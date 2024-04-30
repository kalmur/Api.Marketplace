using Api.Marketplace.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

using ApiUser = Api.Marketplace.Domain.Entities.User;

namespace Api.Marketplace.Application.Workflows.User.CreateUser;

public class CreateUserInDbHandler : INotificationHandler<CreateUserInDbNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateUserInDbHandler> _logger;

    public CreateUserInDbHandler(IApplicationDbContext context, ILogger<CreateUserInDbHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateUserInDbNotification notification, CancellationToken cancellationToken)
    {
        _context.Users.Add(new ApiUser
        {
            ExternalProviderId = notification.ExternalProviderId
        });

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("User {externalProviderId} added to DB", notification.ExternalProviderId);
    }
}
