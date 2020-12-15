using System;
using Utils;

namespace Exercises.Day_10
{
    public class E19 : NumSolver
    {
        public override void Solve()
        {
            int oneJoltDiffs = 0;
            int threeJoltDiffs = 0;
            Input.Add(0);
            Input.Sort();
            for (int i = 0; i < Input.Count - 1; i++)
            {
                int diff = Input[i + 1] - Input[i];
                if (diff == 1)
                {
                    oneJoltDiffs++;
                }
                else if (diff == 3)
                {
                    threeJoltDiffs++;
                }
                else if (diff != 2)
                {
                    throw new ArgumentException($"Diff {diff} is too large between {Input[i + 1]} and {Input[i]}");
                }
            }

            threeJoltDiffs++; // device's built-in adapter
            Console.WriteLine($"The product of diff counts is {oneJoltDiffs * threeJoltDiffs}");
        }
    }
}