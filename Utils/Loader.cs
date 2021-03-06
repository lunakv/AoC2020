﻿using System;
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
                if (int.TryParse(line, out int num))
                    ret.Add(num);
                else
                    throw new FormatException($"String \"{line}\" couldn't be parsed as a number!");

            return ret;
        }

        public static List<int> LoadNumbers(string? path)
        {
            TextReader reader = path == null ? Console.In : new StreamReader(path);
            return LoadNumbers(reader);
        }

        public static List<long> LoadLongNumbers(TextReader reader)
        {
            var ret = new List<long>();
            string? line;
            while ((line = reader.ReadLine()) != null)
                if (long.TryParse(line, out long num))
                    ret.Add(num);
                else
                    throw new FormatException($"String \"{line}\" couldn't be parsed as a number!");

            return ret;
        }

        public static List<long> LoadLongNumbers(string? path)
        {
            TextReader reader = path == null ? Console.In : new StreamReader(path);
            return LoadLongNumbers(reader);
        }

        public static int LoadNumber(TextReader reader)
        {
            string? line = reader.ReadLine();
            if (line == null)
                throw new ArgumentNullException(nameof(line), "Expected number on input, but EOF appeared instead.");

            if (int.TryParse(line, out int num)) return num;

            throw new FormatException($"Input '{line}' couldn't be parsed as a number.");
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
            TextReader reader = path == null ? Console.In : new StreamReader(path);
            return LoadInput(reader);
        }
    }
}