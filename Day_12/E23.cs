using System;
using Utils;

namespace Day_12
{
    public class E23 : E23_24
    {
        public override void Solve()
        {
            var ship = new Ship(Direction.E);
            
            foreach (string line in Input)
            {
                (char instruction, int arg) = ParseInstruction(line);
                switch (instruction)
                {
                    case 'N':
                        ship.Move(arg, Direction.N);
                        break;
                    case 'E':
                        ship.Move(arg, Direction.E);
                        break;
                    case 'S':
                        ship.Move(arg, Direction.S);
                        break;
                    case 'W':
                        ship.Move(arg, Direction.W);
                        break;
                    case 'L':
                        ship.Rotate(arg, false);
                        break;
                    case 'R':
                        ship.Rotate(arg, true);
                        break;
                    case 'F':
                        ship.Move(arg, true);
                        break;
                    default:
                        throw new FormatException($"Unknown instruction: {instruction}.");
                }
            }

            (int x, int y) = ship.Location;
            int distance = ManhattanDistance(ship.Location);
            Console.WriteLine($"Ship ended at ({x},{y}) with Manhattan distance of {distance}.");
        }
    }
}