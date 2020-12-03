using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner.Run(args);
        }
    }

    public static class Runner
    {
        public static void Run(string[] args)
        {
            var (num, path) = Loader.ParseArgs(args);
            var reader = path == null ? Console.In : new StreamReader(path);
            List<string> input = Loader.LoadInput(reader);

            if (num == 5)
            {
                new E5 {Input = input, Slope = (3, 1), TreeChar = '#'}.Solve();
            }
        }
    }
}