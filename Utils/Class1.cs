using System;
using System.Collections.Generic;
using System.IO;

namespace Utils
{
    public static class Loader
    {
        public static List<int> LoadNumbers(TextReader reader)
        {
            var ret = new List<int>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line, out int num))
                {
                    ret.Add(num);
                }
                else
                {
                    throw new FormatException($"String \"{line}\" couldn't be parsed as a number!");
                }
            }

            return ret;
        }

        public static List<string> LoadInput(TextReader reader)
        {
            var ret = new List<string>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                ret.Add(line);
            }

            return ret;
        }

        public static (int, string?) ParseArgs(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("The program needs an exercise number as an argument.");
            }

            if (!int.TryParse(args[0], out int ex))
            {
                throw new ArgumentException("The first argument has to be a number.");
            }

            return (ex, args.Length > 1 ? args[1] : null);
        }
    }

    public interface ISolver
    {
        void Solve();
    }
}