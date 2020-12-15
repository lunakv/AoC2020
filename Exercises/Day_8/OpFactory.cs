using System;

namespace Exercises.Day_8
{
    public class OpFactory
    {
        public Operation Create(string[] args)
        {
            if (args.Length < 2 || !int.TryParse(args[1], out int param))
            {
                throw new FormatException("Instructions need an integer parameter.");
            }

            return args[0] switch
            {
                "nop" => new NopOperation(param),
                "acc" => new AccOperation(param),
                "jmp" => new JmpOperation(param),
                { } s => throw new NotSupportedException($"'{s}' isn't a supported instruction."),
            };
        }
    }
}