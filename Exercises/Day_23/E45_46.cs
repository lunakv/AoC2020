using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_23
{
    public abstract class E45_46 : StringSolver
    {
        protected abstract int Iterations { get; }
        protected (LinkedList<int>, Dictionary<int, LinkedListNode<int>>) ParseInput()
        {
            string input = Input[0];
            var cycle = new LinkedList<int>();
            var values = new Dictionary<int, LinkedListNode<int>>();
            foreach (char digit in input)
            {
                int value = (int) char.GetNumericValue(digit);
                cycle.AddLast(value);
                values.Add(value, cycle.Last ?? throw new Exception("No elements were added to cycle"));
            }

            return (cycle, values);
        }

        protected void Run(LinkedList<int> cycle, Dictionary<int, LinkedListNode<int>> values)
        {
            int max = values.Keys.Max();
            int min = values.Keys.Min();

            var buffer = new LinkedListNode<int>[3];
            var currentNode = cycle.First ?? throw new ArgumentException("Cycle is empty.");
            for (int i = 0; i < Iterations; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    buffer[j] = currentNode.NextOrFirst() ?? throw new Exception("Current node has no Next");
                    cycle.Remove(buffer[j]);
                }
                
                int destination = currentNode.Value - 1;
                while (!values.ContainsKey(destination) || values[destination].List is null)
                {
                    destination = destination <= min ? max : destination - 1;
                }

                var destNode = values[destination] ?? throw new Exception("Searched for non-existent destination.");
                for (int j = 2; j >= 0; j--)
                {
                    cycle.AddAfter(destNode, buffer[j]);
                }

                currentNode = currentNode.NextOrFirst() ?? throw new Exception("Current node has no Next");
            }
        }
    }
}