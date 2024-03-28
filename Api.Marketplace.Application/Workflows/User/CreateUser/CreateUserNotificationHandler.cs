
using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Application.Workflows.User.CreateUser;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Workflows.User.CreateUser
{
public class CreateUserNotificationHandler : INotificationHandler<CreateUserNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateUserNotificationHandler> _logger;

    public CreateUserNotificationHandler(IApplicationDbContext context, ILogger<CreateUserNotificationHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateUserNotification notification, CancellationToken cancellationToken)
    {
            _context.Users.Add(new Domain.Entities.User
            {
                ExternalProviderId = notification.ExternalProviderId
            });
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("User {externalProviderId} added to DB", notification.ExternalProviderId);
        }
    }
}
