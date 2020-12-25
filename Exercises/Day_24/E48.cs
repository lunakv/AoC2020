using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Day_24
{
    public class E48 : E47_48
    {
        private const int Iterations = 100;
        private readonly (int, int)[] _neighbors = {(1, 0), (1, 1), (0, 1), (-1, 0), (-1, -1), (0, -1)};
        public override void Solve()
        {
            HashSet<(int, int)> black = ParseInput().Where(x => x.Value % 2 == 1).Select(x => x.Key).ToHashSet();

            for (int i = 0; i < Iterations; i++)
            {
                black = OneStep(black);
            }

            Console.WriteLine($"After {Iterations} days, there are {black.Count} black tiles");
        }

        private HashSet<(int, int)> OneStep(IReadOnlySet<(int, int)> black)
        {
            var ret = new HashSet<(int, int)>();
            var whiteNeighbors = new Dictionary<(int, int), int>();

            foreach ((int x, int y)  in black)
            {
                int around = 0;
                foreach ((int dX, int dY) in _neighbors)
                {
                    (int, int) neighbor = (x + dX, y + dY);
                    if (black.Contains(neighbor))
                    {
                        around++;
                    }
                    else
                    {
                        whiteNeighbors.TryAdd(neighbor, 0);
                        whiteNeighbors[neighbor]++;
                    }
                }

                // black tiles with 0 or >2 black neighbors flip to white
                if (around > 0 && around <= 2)
                {
                    ret.Add((x, y));
                }
            }

            foreach (((int, int) position, int count) in whiteNeighbors)
            {
                // white tiles with exactly 2 black neighbors flip to black
                if (count == 2)
                {
                    ret.Add(position);
                }
            }

            return ret;
        }
    }
}