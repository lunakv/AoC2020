using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Day_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Runner.Run(args);
        }
    }

    public static class Runner
    {
        public static void Run(string[] args)
        {
            (int num, string? path) = Loader.ParseArgs(args);
            TextReader? reader = path == null ? Console.In : new StreamReader(path);
            List<string> input = Loader.LoadInput(reader);

            if (num == 5)
                new E5 {Input = input, Slope = (3, 1)}.Solve();
            else
                new E6 {Input = input}.Solve();
        }
    }
}