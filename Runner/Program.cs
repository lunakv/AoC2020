using System;
using System.Diagnostics;
using System.Reflection;
using Utils;

namespace Runner
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Parse exercise number and input path
            string? basePath = args.Length > 0 ? args[0].TrimEnd('/', '\\') : null;
            if (args.Length <= 1 || !int.TryParse(args[1], out int ex))
            {
                Console.Write("Select exercise number: ");
                ex = Loader.LoadNumber(Console.In);
            }
            int day = (ex + 1) / 2;
            string? path = basePath is null ? null : $"{basePath}/day{day}.txt";

            // Create exercise solver instance
            string solverName = $"Exercises.Day_{day}.E{ex}";
            Assembly exercises = Assembly.Load("Exercises");
            object? instance = exercises.CreateInstance(solverName);
            if (!(instance is ISolver solver))
            {
                Console.Error.WriteLine($"Solver for exercise {ex} not yet implemented.");
                return;
            }
            
            // Load input into solver
            var totalStopwatch = new Stopwatch();
            totalStopwatch.Start();
            switch (solver)
            {
                case NumSolver n:
                    n.Input = Loader.LoadNumbers(path);
                    break;
                case LongNumSolver l:
                    l.Input = Loader.LoadLongNumbers(path);
                    break;
                case StringSolver s:
                    s.Input = Loader.LoadInput(path);
                    break;
                default:
                    throw new ArgumentException($"Unknown implementation of ISolver: {solver.GetType()}.");
            }

            // Run solver
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            solver.Solve();
            stopwatch.Stop();
            totalStopwatch.Stop();
            Console.WriteLine($"\nSolver ran in {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Total runtime was {totalStopwatch.ElapsedMilliseconds} ms");
        }
    }
}
