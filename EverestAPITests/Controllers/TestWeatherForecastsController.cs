using Castle.Core.Logging;
using EverestAPI;
using EverestAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestAPITests.Controllers
{
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
}
