using MediatR;

namespace Api.Marketplace.Application.Workflows.User.CreateUser;

public class CreateUserInDbNotification : INotification
{
    public CreateUserInDbNotification(string externalProviderId)
    {
        ExternalProviderId = externalProviderId;
    }

    public string ExternalProviderId { get; }
}
