using System;
using System.Collections.Generic;
using Utils;

namespace Day_7
{
    
    
    public class E13 : E13_14
    {
        public override void Solve()
        {
            LoadGraph();
            int total = FindReachable("shiny gold").Count - 1;
            Console.WriteLine($"Shiny gold bag can be in {total} different outer bags.");
        }

        private HashSet<string> FindReachable(string start)
        {
            var open = new Stack<string>();
            var found = new HashSet<string> {start};

            open.Push(start);
            while (open.Count != 0)
            {
                string curr = open.Pop();
                if (!_reverseGraph.ContainsKey(curr)) continue;
                
                foreach ((string neighbor, int _) in _reverseGraph[curr])
                {
                    found.Add(neighbor);
                    open.Push(neighbor);
                }
            }

            return found;
        }
    }
}