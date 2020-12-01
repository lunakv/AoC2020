using System;
using System.Collections.Generic;
using Utils;

namespace Day_1
{
    public class E2 : E12
    {
        public override void Solve()
        {
            var triple = FindTriple();
            if (triple == null)
                Console.WriteLine("No three numbers that add up to 2020 found.");
            else
            {
                Console.WriteLine($"The numbers are {triple.Item1}, {triple.Item2}, and {triple.Item3}");
                Console.WriteLine($"Their product is {triple.Item1 * triple.Item2 * triple.Item3}");
            }
        }

        private Tuple<int, int, int>? FindTriple()
        {
            Input.Sort();
            var pairer = new E1 {Input = Input};
            for (int i = 0; i < Input.Count - 2; i++)
            {
                int n = Input[i];
                pairer.Sum = Sum - n;
                var pair = pairer.FindPair(i+1);
                if (pair == null) continue;
                if (pair.Item1 + pair.Item2 + n == Sum)
                {
                    return new Tuple<int, int, int>(pair.Item1, pair.Item2, n);
                }
            }

            return null;
        }
    }
}