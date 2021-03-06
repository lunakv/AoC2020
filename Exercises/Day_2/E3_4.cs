using System;
using Utils;

namespace Exercises.Day_2
{
    public abstract class E3_4 : StringSolver
    {
        protected (int, int, char, string) ParseLine(string line)
        {
            string[] split = line.Split('-', ' ', ':');
            CheckFormat(line, split);
            return (int.Parse(split[0]), int.Parse(split[1]), split[2][0], split[4]);
        }

        private void CheckFormat(string line, string[] split)
        {
            if (split.Length < 5) throw new FormatException($"Input '{line}' doesn't have the correct format.");

            if (!int.TryParse(split[0], out int _))
                throw new FormatException($"Lower bound of '{line}' is not a number.");

            if (!int.TryParse(split[1], out int _))
                throw new FormatException($"Upper bound of '{line}' is not a number.");

            if (split[2].Length != 1)
                throw new FormatException($"The policy in '{line}' must specify just one character.");
        }
    }
}