using System;
using System.Numerics;

namespace Day_12
{
    public class E24 : E23_24
    {
        public override void Solve()
        {
            var ship = new Ship(Direction.E);
            var waypoint = (1, 10);

            foreach (string line in Input)
            {
                (char instruction, int arg) = ParseInstruction(line);
                switch (instruction)
                {
                    case 'N':
                        waypoint.Item1 += arg;
                        break;
                    case 'E':
                        waypoint.Item2 += arg;
                        break;
                    case 'S':
                        waypoint.Item1 -= arg;
                        break;
                    case 'W':
                        waypoint.Item2 -= arg;
                        break;
                    case 'L':
                        waypoint = RotateRight(waypoint, 4 - arg / 90);
                        break;
                    case 'R':
                        waypoint = RotateRight(waypoint, arg / 90);
                        break;
                    case 'F':
                        ship.Move(arg, waypoint);
                        break;
                    default:
                        throw new FormatException($"Unknown instruction '{instruction}'.");
                }
            }

            (int x, int y) = ship.Location;
            int dist = ManhattanDistance(ship.Location);
            Console.WriteLine($"Ship ended at ({x},{y}) with Manhattan distance of {dist}.");
        }

        private static (int, int) RotateRight((int, int) vector, int count)
        {
            for (int i = 0; i < count; i++)
            {
                vector = (-vector.Item2, vector.Item1);
            }

            return vector;
        }
    }
}