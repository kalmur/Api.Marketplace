using Api.Marketplace.Application.Workflows.User.CreateUser;
using Api.Marketplace.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

#nullable disable
namespace Api.Marketplace.Application.Tests.Workflows.User.CreateUser;

[TestFixture]
[Category(TestCategories.Unit)]
public class CreateUserNotificationHandlerTests : WorkflowBaseTests
{
    [SetUp]
    public void Setup()
    {
        _handler = new CreateUserNotificationHandler(
            Context,
            Substitute.For<ILogger<CreateUserNotificationHandler>>()
        );
    }

    private CreateUserNotificationHandler _handler;

    private const string DemoExternalId = "auth|007";

    [Test]
    public async Task CreateUserResponse_WhenRequestIsValid_SavesUserInDb()
    {
        // Arrange
        var notification = new CreateUserNotification(DemoExternalId);

        // Act
        await _handler.Handle(notification, CancellationToken.None);

        // Assert
        var createdUser = await Context.Users.SingleOrDefaultAsync(
            x => x.ExternalProviderId == DemoExternalId);
        createdUser.ShouldNotBeNull();
    }
}
#nullable enable