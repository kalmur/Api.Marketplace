
using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Application.Workflows.User.CreateUser;
using MediatR;
using Microsoft.Extensions.Logging;

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
        _logger.LogInformation("Creating user in the database {externalProviderId}.", notification.ExternalProviderId);

        _context.Users.Add(new Api.Marketplace.Application.DBModels.User(notification.ExternalProviderId));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
