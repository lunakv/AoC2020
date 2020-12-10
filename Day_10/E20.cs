using System;
using Utils;

namespace Day_10
{
    public class E20 : NumSolver
    {
        public override void Solve()
        {
            Input.Add(0);
            Input.Sort();
            long[] arrangements = new long[Input.Count];
            arrangements[0] = 1;
            for (int i = 1; i < Input.Count; i++)
            {
                arrangements[i] = 0;
                for (int j = i - 1; j >= 0 && Input[i] - Input[j] <= 3; j--)
                {
                    arrangements[i] += arrangements[j];
                }
            }

            Console.WriteLine($"Total number of arrangements is {arrangements[^1]}");
        }
    }
}