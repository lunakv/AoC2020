using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Day_1
{
    static class Program
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
            var (ex, path) = Loader.ParseArgs(args);
            Loader.ValidateExercise(ex, 1, 2);
            List<int> input = Loader.LoadNumbers(path);
            
            if (ex == 1)
            {
                new E1 {Sum = 2020, Input = input}.Solve();
            }
            else
            {
                new E2 {Sum = 2020, Input = input}.Solve();
            }
        }
    }
}