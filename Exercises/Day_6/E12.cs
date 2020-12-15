using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_6
{
    public class E12 : StringSolver
    {
        public override void Solve()
        {
            int total = 0;
            var answered = new Dictionary<char, int>();
            int groupSize = 0;

            foreach (string line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    total += answered.Count(pair => pair.Value == groupSize);
                    answered.Clear();
                    groupSize = 0;
                }
                else
                {
                    groupSize++;
                    foreach (char c in line)
                    {
                        if (!answered.TryAdd(c, 1))
                        {
                            answered[c]++;
                        }
                    }
                }
            }

            total += answered.Count(pair => pair.Value == groupSize);
            Console.WriteLine($"Sum of all ubiquitous answers is {total}.");

        }
    }
}