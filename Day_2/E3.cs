using System;
using System.Collections.Generic;
using Utils;

namespace Day_2
{
    public class E3 : E34
    {
        public override void Solve()
        {
            int correct = 0;
            foreach (string line in Input)
            {
                int count = 0;
                var (lower, upper, letter, passwd) = ParseLine(line);
                foreach (char c in passwd)
                {
                    if (c == letter) count++;
                }

                if (count <= upper && count >= lower)
                {
                    correct++;
                }
            }

            Console.WriteLine($"Found {correct} correct passwords in the database.");
        }
    }
}