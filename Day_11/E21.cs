using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_11
{
    public class E21 : E21_22
    {
        protected override int OccupiedNeeded { get; } = 4;

        public override void Solve()
        {

            char[][] end = Run();
            int occupied = CountOccupied(end);
            Console.WriteLine($"Seating stabilized at {occupied} occupied seats.");
        }

        // Count occupied seats around (i,j)
        protected override int CountAround(char[][] from, int i, int j)
        {
            int ret = 0;
            int lI = (i == 0) ? i : i - 1;
            int hI = (i == from.Length - 1) ? i : i + 1;
            int lJ = (j == 0) ? j : j - 1;
            int hJ = (j == from[i].Length - 1) ? j : j + 1;
            for (int ii = lI ; ii <= hI; ii++)
            {
                for (int jj = lJ; jj <= hJ; jj++)
                {
                    if (ii == i && jj == j) continue;
                    if (from[ii][jj] == Occupied)
                    {
                        ret++;
                    }
                }
            }

            return ret;
        }
    }
}