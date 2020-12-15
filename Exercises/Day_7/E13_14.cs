using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_7
{
    using Graph = Dictionary<string, List<(string, int)>>;
    
    public abstract class E13_14 : StringSolver
    {
        protected readonly Graph ReverseGraph = new();
        protected readonly Graph ForwardGraph = new();
        
        protected void LoadGraph()
        {
            foreach (string rule in Input)
            {
                string[] split = rule.Split(" bags contain ", StringSplitOptions.RemoveEmptyEntries);
                string container = split[0];
                string[] contents = split[1].Split(
                    new[] {" bag, ", " bags, ", " bag.", " bags."},
                    StringSplitOptions.RemoveEmptyEntries);

                ForwardGraph.TryAdd(container, new List<(string, int)>());
                
                foreach (string content in contents)
                {
                    string[] splitContent = content.Split(null, 2);
                    if (int.TryParse(splitContent[0], out int value))
                    {
                        ForwardGraph[container].Add((splitContent[1], value));
                        ReverseGraph.TryAdd(splitContent[1], new List<(string, int)>());
                        ReverseGraph[splitContent[1]].Add((container, value));
                    }
                }

            }
        }
    }
}