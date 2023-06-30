namespace MarsRover;

public enum Direction
{
    N,
    S,
    E,
    W
}

public enum Commands
{
    f,
    b
}

public class TestRover
{
    public TestRover(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public Direction Direction { get; set; }


    public void InputCommands(Commands[] commands)
    {
        foreach (var command in commands)
            if (command == Commands.f)
                Y = Y + 1;
    }
}