using FluentAssertions;
using MarsRover;
using Xunit;

namespace MarsRoverTests;

public class MarRoverTestSuite
{
    [Fact]
    public void MarRoverInitial()
    {
        var rover = new MarRover(0, 0, Directions.N);

        rover.Should().NotBeNull();
    }


    [Theory]
    [InlineData(Directions.N, 0, 0, 0, 1)]
    [InlineData(Directions.E, 0, 0, 1, 0)]
    [InlineData(Directions.W, 0, 0, 5, 0)]
    [InlineData(Directions.S, 0, 0, 0, 5)]
    public void ShouldMoveForward(Directions inputDirection, int x, int y, int expectedX, int expectedY)
    {
        var rover = new MarRover(x, y, inputDirection);
        rover.InputCommands(new[] { Moves.F });

        var isCorrect = rover.X == expectedX && rover.Y == expectedY;
        isCorrect.Should().BeTrue();
    }

    [Theory]
    [InlineData(Directions.N, 0, 0, 0, 5)]
    [InlineData(Directions.E, 0, 0, 5, 0)]
    [InlineData(Directions.W, 0, 0, 1, 0)]
    [InlineData(Directions.S, 0, 0, 0, 1)]
    public void ShouldMoveBackward(Directions inputDirection, int x, int y, int expectedX, int expectedY)
    {
        var rover = new MarRover(x, y, inputDirection);
        rover.InputCommands(new[] { Moves.B });

        var isCorrect = rover.X == expectedX && rover.Y == expectedY;
        isCorrect.Should().BeTrue();
    }

    [Theory]
    [InlineData(Directions.N, Directions.W)]
    [InlineData(Directions.E, Directions.N)]
    [InlineData(Directions.W, Directions.S)]
    [InlineData(Directions.S, Directions.E)]
    public void ShowTurnLeft(Directions inputDirection, Directions expectedDirection)
    {
        var rover = new MarRover(0, 0, inputDirection);

        rover.TurnLeft();

        rover.Direction.Should().Be(expectedDirection);
    }

    [Theory]
    [InlineData(Directions.N, Directions.E)]
    [InlineData(Directions.E, Directions.S)]
    [InlineData(Directions.W, Directions.N)]
    [InlineData(Directions.S, Directions.W)]
    public void ShowTurnRight(Directions inputDirection, Directions expectedDirection)
    {
        var rover = new MarRover(0, 0, inputDirection);

        rover.TurnRight();

        rover.Direction.Should().Be(expectedDirection);
    }


    [Theory]
    [InlineData(Directions.W, 0, 0, 5, 0)]
    [InlineData(Directions.E, 5, 0, 0, 0)]
    [InlineData(Directions.N, 0, 5, 0, 0)]
    [InlineData(Directions.S, 0, 0, 0, 5)]

    public void ShouldMoveForward_WrapAroundEdge(Directions inputDirection, int x, int y, int expectedX, int expectedY)
    {
        var rover = new MarRover(x, y, inputDirection);
        rover.InputCommands(new[] { Moves.F });

        var isCorrect = rover.X == expectedX && rover.Y == expectedY;
        isCorrect.Should().BeTrue();
    }

    [Theory]
    [InlineData(Directions.W, 5, 0, 0, 0)]
    [InlineData(Directions.E, 0, 0, 5, 0)]
    [InlineData(Directions.N, 0, 0, 0, 5)]
    [InlineData(Directions.S, 0, 5, 0, 0)]

    public void ShouldMoveBackward_WrapAroundEdge(Directions inputDirection, int x, int y, int expectedX, int expectedY)
    {
        var rover = new MarRover(x, y, inputDirection);
        rover.InputCommands(new[] { Moves.B });

        var isCorrect = rover.X == expectedX && rover.Y == expectedY;
        isCorrect.Should().BeTrue();
    }
}