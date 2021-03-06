using System;

namespace Exercises.Day_3
{
    public class E6 : E5_6
    {
        public override void Solve()
        {
            var slopes = new[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};

            ulong total = 1;
            foreach ((int, int) slope in slopes)
            {
                Slope = slope;
                uint trees = CountTrees();
                total *= trees;
            }

            Console.WriteLine($"The product of all the slopes is {total}.");
        }
    }
}