using System;
using System.Collections.Generic;
using Utils;

namespace Day_4
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
            (int ex, string? path) = Loader.ParseArgs(args);
            Loader.ValidateExercise(ex, 7, 8);
            List<string> input = Loader.LoadInput(path);

            if (ex == 7)
            {
                new E7 {Input = input}.Solve();
            }
            else
            {
                // new E8 {Input = input}.Solve();
            }

        }
    }
}