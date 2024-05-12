using Api.Marketplace.Testing;
using Api.Marketplace.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

#nullable disable
namespace Api.Marketplace.WebApi.Tests.Controllers;

[TestFixture]
[Category(TestCategories.Unit)]
public class CitiesControllerTests
{
    //[SetUp]
    //public void Setup()
    //{
    //    _mockMediator = Substitute.For<IMediator>();
    //    _controller = new CitiesController(_mockMediator);
    //}

    //private IMediator _mockMediator;
    //private CitiesController _controller;

    //private const string CityName = "Szeged";
    //private const string CountryName = "Hungary";

    //[Test]
    //public async Task CreateCitiesAsync_WhenRequestIsValid_Returns201Created()
    //{
    //    // Arrange
    //    var createCitiesRequest = new CreateCitiesRequest(CityName, CountryName);
    //    var createCitiesResponse = new CreateCitiesResponse(1);

    //    _mockMediator.Send(Arg.Any<CreateCitiesRequest>()).Returns(createCitiesResponse);

    //    // Act
    //    var result = await _controller.CreateCitiesAsync(createCitiesRequest);

    //    // Assert
    //    result.ShouldNotBeNull();
    //    result.ShouldBeOfType<CreatedResult>();

    //    var createdResult = (CreatedResult)result;
    //    createdResult.Location.ShouldBe($"/api/cities");

    //    await _mockMediator.Received(1).Send(Arg.Is<CreateCitiesRequest>(
    //            x => x.Name == CityName &&
    //            x.Country == CountryName));
    //}
}
#nullable enable