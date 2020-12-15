using System;
using System.Linq;

namespace Exercises.Day_11
{
    public class E22 : E21_22
    {
        private readonly (int, int)[] _slopes = {(0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1), (-1, 0), (1, 0)};

        
        protected override int OccupiedNeeded { get; } = 5;

        public override void Solve()
        {
            int res = CountOccupied(Run());
            Console.WriteLine($"The end result has {res} occupied seats.");
        }

        // Count occupied chairs visible from (i,j)
        protected override int CountAround(char[][] from, int i, int j) =>
            _slopes.Count(slope => FindFirstChair(from, (i, j), slope) == Occupied);
        

        private char FindFirstChair(char[][] from, (int, int) init, (int, int) slope)
        {
            (int dI, int dJ) = slope;
            int ii = init.Item1 + dI;
            int jj = init.Item2 + dJ;
            while (ii >= 0 && ii < from.Length && jj >= 0 && jj < from[0].Length)
            {
                if (from[ii][jj] != Floor)
                {
                    return from[ii][jj];
                }

                ii += dI;
                jj += dJ;
            }

            return '\0';
        }
    }
}