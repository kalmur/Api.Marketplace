using Api.Marketplace.Application.Workflows.Cities.CreateCities;
using Api.Marketplace.Testing;
using NUnit.Framework;
using Shouldly;

#nullable enable
namespace Api.Marketplace.Application.Tests.Workflows.Cities.CreateCities;

[TestFixture]
[Category(TestCategories.Unit)]
public class CreateCitiesResponseTests
{
    [Test]
    public void CreateCities_WhenRequestIsValid_ReturnsNoteId()
    {
        // Arrange
        var cityId = 1;

        // Act
        var response = new CreateCitiesResponse(cityId);

        // Assert
        response.CityId.ShouldBe(cityId);
    }
}
#nullable disable
