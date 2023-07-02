using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestAPI
{

    public class Obstacle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Obstacle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class ObstacleList
    {
        public List<Obstacle> Obstacles { get; private set; } = new List<Obstacle>();
        public ObstacleList() { }
        public void AddObstacle(int x, int y)
        {
            this.Obstacles.Add(new Obstacle(x, y));
        }
        public bool IsHit(int x, int y)
        {
            return this.Obstacles.Exists(d => d.X == x && d.Y == y);
        }
    }

    public class MarsRover
    {


        private ObstacleList obstacleList = new ObstacleList();
        private int maxX = 10;
        private int maxY = 10;
        private List<string> compass = new List<string> { "N", "E", "S", "W" };
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Direction { get; private set; }
        public MarsRover(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;

            // Add an obstacle
            obstacleList.AddObstacle(1, 1);
        }

        public void execute(string[] commands)
        {
            foreach (var command in commands)
            {
                executeCommand(command);
            }

        }

        public void executeCommand(string commandName)
        {
            int newX = X;
            int newY = Y;
            switch (commandName)
            {
                case "F": (newX, newY) = moveForward(); break;
                case "B": (newX, newY) = moveBackward(); break;
                case "L": turnLeft(); break;
                case "R": turnRight(); break;
            }

            // Check whether the new coordindate hits an obstacle.
            if (obstacleList.IsHit(newX, newY))
                throw new Exception($"Obstacle at x:{newX}, y:{newY} hit! Self destructing");


            // If we have reach here, we update the new coordinates of the Mars Rover
            Y = newY; X = newX;
        }

        private (int x, int y) moveForward()
        {
            var newY = Y;
            var newX = X;

            switch (Direction)
            {
                case "N":
                    newY++;
                    if (newY >= maxY) newY = 0;
                    break;

                case "S":
                    newY--;
                    if (newY <= -1) newY = maxY - 1;
                    break;
                case "E":
                    newX++;
                    if (newX >= maxX) newX = 0;
                    break;
                case "W":
                    newX--;
                    if (newX <= -1) newX = maxX - 1;
                    break;
            }

            return (newX, newY);


        }
        private (int x, int y) moveBackward()
        {
            var newY = Y;
            var newX = X;

            switch (Direction)
            {
                case "N":
                    newY--;
                    if (newY <= -1) newY = maxY - 1;
                    break;
                case "S":
                    newY++;
                    if (newY >= maxY) newY = 0;
                    break;
                case "E":
                    newX--;
                    if (newX <= -1) newX = maxX - 1;
                    break;
                case "W":
                    newX++;
                    if (newX >= maxX) newX = 0;
                    break;
            }

            return (newX, newY);


        }

        public void turnLeft()
        {
            var currentDirection = compass.IndexOf(this.Direction);
            if (currentDirection == 0)
            {
                this.Direction = compass[3];
                return;
            }
            this.Direction = compass[currentDirection - 1];
        }

        public void turnRight()
        {
            var currentDirection = compass.IndexOf(this.Direction);
            if (currentDirection == 3)
            {
                this.Direction = compass[0];
                return;
            }
            this.Direction = compass[currentDirection + 1];
        }

    }
}
