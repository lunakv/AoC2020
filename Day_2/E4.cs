using System;

namespace Day_2
{
    public class E4 : E34
    {
        public override void Solve()
        {
            int correct = 0;
            foreach (string line in Input)
            {
                var (lower, upper, letter, passwd) = ParseLine(line);
                lower--;
                upper--;
                if (upper >= passwd.Length)
                {
                    throw new FormatException($"Bound {upper} is higher than the length of '{passwd}'.");
                }

                int count = 0;
                if (passwd[lower] == letter) count++;
                if (passwd[upper] == letter) count++;
                if (count == 1) correct++;
            }

            Console.WriteLine($"Found {correct} correct passwords in the database.");
        }
    }
}