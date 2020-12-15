using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_6
{
    public class E11 : StringSolver
    {
        public override void Solve()
        {
            int total = 0;
            var answered = new HashSet<char>();
            foreach (string line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    total += answered.Count;
                    answered.Clear();
                }
                else
                {
                    foreach (char c in line)
                    {
                        answered.Add(c);
                    }
                }
            }

            total += answered.Count;
            Console.WriteLine($"The answer total is {total}.");
        }
    }
}