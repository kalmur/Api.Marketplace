using MediatR;

namespace Api.Marketplace.Application.Workflows.User.CreateUser
{
public class CreateUserNotification : INotification
{
    public CreateUserNotification(string externalProviderId)
    {
        ExternalProviderId = externalProviderId;
    }

    public string ExternalProviderId { get; }
}
}
