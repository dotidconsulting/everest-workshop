using FluentAssertions;
using MarsRover;
using Xunit;

namespace MarsRoverTests;

public class TestRoverSuite
{
    [Fact]
    public void TestRoverFunction()
    {
        var t = new TestRover(0, 0, Direction.E);

        t.Should().NotBeNull();
    }

    [Fact]
    public void TestRoverInitial()
    {
        var expectedX = 0;
        var expectedY = 0;
        var expectedDirection = Direction.E;
        var rover = new TestRover(expectedX, expectedY, expectedDirection);

        rover.X.Should().Be(expectedX);
        rover.Y.Should().Be(expectedY);
        rover.Direction.Should().Be(expectedDirection);
    }

    [Fact]
    public void TestMoveCommand()
    {
        var rover = new TestRover(0, 0, Direction.E);
        
        rover.InputCommands(new Commands [] { Commands.b, Commands.f});
    }


    [Fact]
    public void TestRoverReceiveCommands()
    {
        var expectedX = 0;
        var initialY = 0;
        var expectedY = initialY + 1;

        var expectedDirection = Direction.N;

        var rover = new TestRover(expectedX, initialY, expectedDirection);
        rover.InputCommands(new Commands[] { Commands.f});

        rover.Direction.Should().Be(expectedDirection);
        rover.X.Should().Be(expectedX);
        rover.Y.Should().Be(expectedY);
    }
}