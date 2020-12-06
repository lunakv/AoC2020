using System;
using System.Collections.Generic;
using Utils;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public static class Runner
    {
        public static void Run(string[] args)
        {
            (int ex, string? path) = Loader.ParseArgs(args);
            Loader.ValidateExercise(ex, 9, 10);
            List<string> input = Loader.LoadInput(path);

            if (ex == 9)
            {
                new E9 {Input = input}.Solve();
            }
            else
            {
                // new E10 {Input = input}.Solve();
            }
        }
    }
}