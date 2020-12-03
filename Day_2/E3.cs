using System;

namespace Day_2
{
    public class E3 : E34
    {
        public override void Solve()
        {
            var correct = 0;
            foreach (string line in Input)
            {
                var count = 0;
                (int lower, int upper, char letter, var passwd) = ParseLine(line);
                foreach (char c in passwd)
                    if (c == letter)
                        count++;

                if (count <= upper && count >= lower) correct++;
            }

            Console.WriteLine($"Found {correct} correct passwords in the database.");
        }
    }
}