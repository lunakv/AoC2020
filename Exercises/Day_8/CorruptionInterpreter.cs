using System;
using System.Collections.Generic;

namespace Exercises.Day_8
{
    public class CorruptionInterpreter
    {
        private readonly List<Operation> _instructions;

        public CorruptionInterpreter(IParser parser, List<string> input)
        {
            _instructions = parser.ParseInput(input);
        }

        public int Run()
        {
            var possibleCorruptions = new List<int>();
            for (int i = 0; i < _instructions.Count; i++)
            {
                if (_instructions[i] is NopOperation or JmpOperation)
                    possibleCorruptions.Add(i);
            }

            foreach (int index in possibleCorruptions)
            {
                SwitchOperation(index, _instructions);
                if (TryRun(_instructions, out int acc))
                {
                    return acc;
                }
                SwitchOperation(index, _instructions);
            }
            
            throw new FormatException("All fixes entered a loop.");
        }

        private bool TryRun(List<Operation> instructions, out int acc)
        {
            var inter = new LoopInterpreter(instructions);
            acc = inter.Run();
            return inter.ReachedEnd;
        }

        private void SwitchOperation(int index, List<Operation> instructions)
        {
            instructions[index] = instructions[index] switch
            {
                NopOperation => new JmpOperation(instructions[index].N),
                JmpOperation => new NopOperation(instructions[index].N),
                _ => instructions[index]
            };
        }
    }
}