using System;
using System.Collections.Generic;
using Utils;

namespace Day_2
{
    public abstract class E34 : StringSolver
    {
        protected (int, int, char, string) ParseLine(string line)
        {
            var split = line.Split('-', ' ', ':');
            CheckFormat(line, split);
            return (int.Parse(split[0]), int.Parse(split[1]), split[2][0], split[4]);
        }

        private void CheckFormat(string line, string[] split)
        {
            if (split.Length < 5)
            {
                throw new FormatException($"Input '{line}' doesn't have the correct format.");
            }

            if (!int.TryParse(split[0], out int lower))
            {
                throw new FormatException($"Lower bound of '{line}' is not a number.");
            }

            if (!int.TryParse(split[1], out int upper))
            {
                throw new FormatException($"Upper bound of '{line}' is not a number.");
            }

            if (split[2].Length != 1)
            {
                throw new FormatException($"The policy in '{line}' must specify just one character.");
            }
        }
    }
}