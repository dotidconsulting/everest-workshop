using EverestAPI;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestAPITests
{
    public class RoverTests
    {
        [Fact]
        public void MarRover_Can_Initialise_With_Coord_Directions()
        {
            var rover = new MarsRover(0, 0, "N");
            rover.X.Should().Be(0);
            rover.Y.Should().Be(0);
            rover.Direction.Should().Be("N");
        }

        [Fact]
        public void MarRover_Can_Accept_command()
        {
            var rover = new MarsRover(0, 0, "N");
            rover.execute(new string[] { "F" });
        }
        [Fact]
        public void MarsRover_Can_Go_Forward_In_North()
        {
            var rover = new MarsRover(0, 0, "N");
            rover.execute(new string[] { "F" });
            rover.Y.Should().Be(1);

        }

        [Theory]
        [InlineData("N", "R", "E")]
        [InlineData("E", "R", "S")]
        [InlineData("S", "R", "W")]
        [InlineData("W", "R", "N")]
        [InlineData("N", "L", "W")]
        [InlineData("W", "L", "S")]
        [InlineData("S", "L", "E")]
        [InlineData("E", "L", "N")]
        public void MarsRover_Can_Change_Direction(string currentDirection, string turnDirection, string expectedDirection)
        {
            var rover = new MarsRover(0, 0, currentDirection);
            rover.execute(new string[] { turnDirection });
            rover.Direction.Should().Be(expectedDirection);

        }

        [Theory]
        [InlineData(0, 1, "F", "N", 0, 2)]
        [InlineData(0, 1, "B", "N", 0, 0)]
        [InlineData(1, 1, "F", "E", 2, 1)]
        [InlineData(1, 1, "B", "E", 0, 1)]
        [InlineData(1, 1, "F", "W", 0, 1)]
        [InlineData(1, 1, "B", "W", 2, 1)]
        [InlineData(0, 1, "F", "S", 0, 0)]
        [InlineData(0, 1, "B", "S", 0, 2)]
        [InlineData(0, 9, "F", "N", 0, 0)]
        [InlineData(0, 0, "B", "N", 0, 9)]
        [InlineData(0, 0, "F", "S", 0, 9)]
        [InlineData(0, 9, "B", "S", 0, 0)]
        [InlineData(9, 0, "F", "E", 0, 0)]
        [InlineData(0, 0, "B", "E", 9, 0)]
        [InlineData(0, 0, "F", "W", 9, 0)]
        [InlineData(9, 0, "B", "W", 0, 0)]
        public void MarsRover_Can_Move(int x, int y, string cmd, string d, int expectedX, int expectedY)
        {
            var rover = new MarsRover(x, y, d);
            rover.execute(new string[] { cmd });
            rover.Y.Should().Be(expectedY);
            rover.X.Should().Be(expectedX);

        }

        [Fact]
        public void MarsRover_Aborts_When_Hitting_Obstacle()
        {
            var rover = new MarsRover(0, 0, "N");

            rover.Invoking(y => y.execute(new string[] { "F", "R", "F" }))
                .Should().Throw<Exception>()
                .WithMessage("Obstacle at x:1, y:1 hit! Self destructing");

        }


    }
}
