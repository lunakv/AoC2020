using System;
using System.Linq;

namespace Exercises.Day_2
{
    public class E3 : E3_4
    {
        public override void Solve()
        {
            int correct = 0;
            foreach (string line in Input)
            {
                (int lower, int upper, char letter, var passwd) = ParseLine(line);
                int count = passwd.Count(c => c == letter);

                if (count <= upper && count >= lower) correct++;
            }

            Console.WriteLine($"Found {correct} correct passwords in the database.");
        }
    }
}