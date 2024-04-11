using System.Net;
using Api.Marketplace.Application.Workflows.Cities.CreateCities;
using Api.Marketplace.Testing;
using NUnit.Framework;
using Shouldly;

#nullable disable
namespace Api.Marketplace.WebApi.Tests.Integration.Controllers.Cities;

[TestFixture]
[Category(TestCategories.Integration)]
public class CreateCitiesTests : IntegrationTestBase
{
    [OneTimeSetUp]
    public void SetUp()
    {
        _httpClient = CreateClient();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
        Dispose();
    }

    private HttpClient _httpClient;

    private const string CityName = "Szeged";
    private const string CountryName = "Hungary";

    [Test]
    public async Task CreateCities_WhenRequestIsValid_AddsNewCity()
    {
        // Arrange
        var request = new CreateCitiesRequest(CityName, CountryName);

        // Act
        var response = await _httpClient.PostAsync(
            $"/api/cities", 
            SerializeContent(request)
        );

        // Assert
        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        //var createdCity = await DeserializeResponseBody<CreateCitiesResponse>(response);
        //createdCity.ShouldNotBeNull();
        //createdCity.CityId.ShouldNotBeNull();
    }
}
#nullable enable