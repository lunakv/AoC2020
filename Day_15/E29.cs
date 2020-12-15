using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_15
{
    public class E29 : StringSolver
    {
        public long Iterations { get; init; }
        
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
                long newLast = occurrences.ContainsKey(last) ? i - occurrences[last] : 0;
                occurrences[last] = i;
                last = newLast;
            }

            Console.WriteLine($"Last number is {last}");
        }

        private List<int> ParseStart(string line) => line.Split(',').Select(int.Parse).ToList();
    }
}