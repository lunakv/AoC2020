using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Utils
{
    public static class Loader
    {
        public static List<int> LoadNumbers(TextReader reader)
        {
            var ret = new List<int>();
            string? line;
            while ((line = reader.ReadLine()) != null)
                if (int.TryParse(line, out int num))
                    ret.Add(num);
                else
                    throw new FormatException($"String \"{line}\" couldn't be parsed as a number!");

            return ret;
        }

        public static List<int> LoadNumbers(string? path)
        {
            TextReader? reader = path == null ? Console.In : new StreamReader(path);
            return LoadNumbers(reader);
        }

        public static int LoadNumber(TextReader reader)
        {
            string? line = reader.ReadLine();
            if (line == null)
                throw new ArgumentNullException(nameof(line), "Expected number on input, but EOF appeared instead.");

            if (int.TryParse(line, out int num)) return num;

            throw new ArgumentException($"Input '{line}' couldn't be parsed as a number.", nameof(line));
        }

        public static List<string> LoadInput(TextReader reader)
        {
            var ret = new List<string>();
            string? line;
            while ((line = reader.ReadLine()) != null) ret.Add(line);

            return ret;
        }

        public static List<string> LoadInput(string? path)
        {
            TextReader? reader = path == null ? Console.In : new StreamReader(path);
            return LoadInput(reader);
        }

        public static (int, string?) ParseArgs(string[] args)
        {
            if (args.Length < 1) throw new ArgumentException("The program needs an exercise number as an argument.");

            if (!int.TryParse(args[0], out int ex))
                throw new ArgumentException("The first argument has to be a number.");

            return (ex, args.Length > 1 ? args[1] : null);
        }

        public static void ValidateExercise(int num, params int[] allowed)
        {
            if (!allowed.Contains(num))
                throw new ArgumentOutOfRangeException(nameof(num),
                    $"Exercise number {num} is invalid for this project.");
        }
    }
}