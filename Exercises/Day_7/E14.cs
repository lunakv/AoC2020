using System;

namespace Exercises.Day_7
{
    public class E14 : E13_14
    {
        public override void Solve()
        {
            LoadGraph();
            Console.WriteLine($"Shiny gold bag needs to contain {CountContents("shiny gold")} bags inside.");
            
        }

        private long CountContents(string bag)
        {
            if (!_forwardGraph.ContainsKey(bag)) return 0;

            long total = 0;
            foreach ((string inside, int count) in _forwardGraph[bag])
            {
                total += count;
                total += count * CountContents(inside);
            }

            return total;
        }
    }
}