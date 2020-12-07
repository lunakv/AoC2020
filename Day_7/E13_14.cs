using System;
using System.Collections.Generic;
using Utils;

namespace Day_7
{
    using Graph = Dictionary<string, List<(string, int)>>;
    
    public abstract class E13_14 : StringSolver
    {
        protected readonly Graph _reverseGraph = new Graph();
        protected readonly Graph _forwardGraph = new Graph();
        
        protected void LoadGraph()
        {
            foreach (string rule in Input)
            {
                var separators = new[] {"bags contain", "bag,", "bag.", "bags,", "bags."};
                var split = rule.Split(" bags contain ", StringSplitOptions.RemoveEmptyEntries);
                string container = split[0];
                var contents = split[1].Split(
                    new[] {" bag, ", " bags, ", " bag.", " bags."},
                    StringSplitOptions.RemoveEmptyEntries);

                _forwardGraph.TryAdd(container, new List<(string, int)>());
                
                foreach (string content in contents)
                {
                    var splitContent = content.Split(null, 2);
                    if (int.TryParse(splitContent[0], out int value))
                    {
                        _forwardGraph[container].Add((splitContent[1], value));
                        _reverseGraph.TryAdd(splitContent[1], new List<(string, int)>());
                        _reverseGraph[splitContent[1]].Add((container, value));
                    }
                }

            }
        }
    }
}