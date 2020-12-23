using System;
using System.Linq;

namespace Exercises.Day_23
{
    public class E46 : E45_46
    {
        protected override int Iterations { get; } = 10_000_000;
        
        public override void Solve()
        {
            var (cycle, values) = ParseInput();
            for (int i = values.Keys.Max() + 1; i <= 1_000_000; i++)
            {
                cycle.AddLast(i);
                values.Add(i, cycle.Last ?? throw new Exception("Cycle has no last element"));
            }
            Run(cycle, values);

            var oneNode = cycle.Find(1) ?? throw new Exception("No '1' node found.");
            var next = oneNode.NextOrFirst() ?? throw new Exception("'1' has no Next");
            var nextNext = next.NextOrFirst() ?? throw new Exception("'1.Next' has no Next");
            Console.WriteLine($"The values after '1' are {next.Value} and {nextNext.Value}");
            Console.WriteLine($"Their product is {(long) next.Value * (long) nextNext.Value}");
        }

        
    }
}