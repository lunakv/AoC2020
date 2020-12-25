using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_24
{
    public class E47 : E47_48
    {
        public override void Solve()
        {
            Dictionary<(int, int), int> flips = ParseInput();
            Console.WriteLine($"Number of black tiles is {flips.Values.Count(x => x % 2 == 1)}");
        }
    }
}