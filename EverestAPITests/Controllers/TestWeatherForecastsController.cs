using EverestAPI;
using EverestAPI.Controllers;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace EverestAPITests.Controllers;

public class TestWeatherForecastsController
{
    [Fact]
    public void Get_ShouldReturnListOfWeatherForecast()
    {
        // Arrange
        var logger = new Mock<ILogger<WeatherForecastController>>();
        var sut = new WeatherForecastController(logger.Object);


        // Act
        var result = sut.Get();


        // Assert
        result.Should().BeAssignableTo(typeof(IEnumerable<WeatherForecast>));
    }
}