namespace MarsRover;

public enum Directions
{
    N,
    W,
    S,
    E
}

public enum Moves
{
    F,
    B
}

public class MarRover
{
    private const int GridX = 5;
    private const int GridY = 5;

    public MarRover(int x, int y, Directions direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Directions Direction { get; set; }

    public void InputCommands(Moves[] moves)
    {
        foreach (var move in moves)
        {
            switch (move)
            {
                case Moves.F:
                    MoveForward();
                    break;
                case Moves.B:
                    MoveBackward();
                    break;
            }

            IsValidCoordinate();
        }
    }

    public void IsValidCoordinate()
    {
        if (X > GridX)
            X = 0;
        if (X < 0)
            X = GridX;

        if (Y > GridX)
            Y = 0;
        if (Y < 0)
            Y = GridY;
    }

    public void MoveForward()
    {
        switch (Direction)
        {
            case Directions.N:
                Y++;
                break;
            case Directions.W:
                X--;
                break;
            case Directions.S:
                Y--;
                break;
            case Directions.E:
                X++;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void MoveBackward()
    {
        switch (Direction)
        {
            case Directions.N:
                Y--;
                break;
            case Directions.W:
                X++;
                break;
            case Directions.S:
                Y++;
                break;
            case Directions.E:
                X--;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void TurnLeft()
    {
        Direction = Direction switch
        {
            Directions.N => Directions.W,
            Directions.W => Directions.S,
            Directions.S => Directions.E,
            Directions.E => Directions.N,
            _ => Direction
        };
    }

    public void TurnRight()
    {
        Direction = Direction switch
        {
            Directions.N => Directions.E,
            Directions.W => Directions.N,
            Directions.S => Directions.W,
            Directions.E => Directions.S,
            _ => Direction
        };
    }
}