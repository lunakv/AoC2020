using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_15
{
    public abstract class E29_30 : StringSolver
    {
        protected abstract long Iterations { get; }
        
        public override void Solve()
        {
            List<int> sequence = ParseStart(Input[0]);
            var occurrences = new Dictionary<long, long>();
            for (int i = 0; i < sequence.Count - 1; i++)
            {
                occurrences[sequence[i]] = i + 1;
            } 
            
            long last = sequence[^1];
            
            for (long i = sequence.Count; i < Iterations; i++)
            {
                long newLast = occurrences.TryGetValue(last, out long val) ? i - val : 0;
                occurrences[last] = i;
                last = newLast;
            }

            Console.WriteLine($"Last number is {last}");
        }

        private List<int> ParseStart(string line) => line.Split(',').Select(int.Parse).ToList();
    }

    public class E29 : E29_30
    {
        protected override long Iterations { get; } = 2020;
    }
    
    public class E30 : E29_30
    {
        protected override long Iterations { get; } = 30_000_000;
    }
}