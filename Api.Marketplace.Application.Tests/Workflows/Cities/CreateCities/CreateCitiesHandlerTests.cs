using Api.Marketplace.Application.Workflows.Cities.CreateCities;
using Api.Marketplace.Testing;
using NUnit.Framework;
using Shouldly;

#nullable disable
namespace Api.Marketplace.Application.Tests.Workflows.Cities.CreateCities;

[TestFixture]
[Category(TestCategories.Unit)]
public class CreateCitiesHandlerTests : WorkflowBaseTests
{
    [SetUp]
    public void SetUp()
    {
        _handler = new CreateCitiesHandler(Context);
    }

    private CreateCitiesHandler _handler;

    private const string CityName = "Szeged";
    private const string CountryName = "Hungary";

    [Test]
    public async Task Handle_WhenRequestIsValid_ReturnsCityId()
    {
        // Arrange
        var request = new CreateCitiesRequest(CityName, CountryName);

        // Act
        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.CityId.ShouldBeGreaterThan(0);
    }
}
#nullable enable
