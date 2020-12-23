using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_23
{
    public class E45 : E45_46
    {
        protected override int Iterations { get; } = 100;

        public override void Solve()
        {
            var (cycle, values) = ParseInput();
            Run(cycle, values);
            
            var oneNode = cycle.Find(1) ?? throw new ArgumentException("There's no '1' node in cycle.");
            for (var currNode = oneNode.NextOrFirst(); currNode != oneNode; currNode = currNode.NextOrFirst())
            {
                if (currNode is null) throw new Exception("Trying to print nonexistent Next");
                Console.Write(currNode.Value);
            }
            
        }
    }
}