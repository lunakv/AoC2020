using System;
using Utils;

namespace Day_6
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
            Loader.ValidateExercise(ex, 11, 12);
            var input = Loader.LoadInput(path);

            if (ex == 11)
            {
                new E11 {Input = input}.Solve();
            }
            else
            {
                new E12 {Input = input}.Solve();
            }
        }
    }
}