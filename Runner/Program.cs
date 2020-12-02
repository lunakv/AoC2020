using System;
using Utils;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = (args.Length > 0) ? args[0].TrimEnd('/', '\\') : ".";
            
            Console.Write("Select exercise number: ");
            int num = Loader.LoadNumber(Console.In);
            args = new[] { num.ToString(), $"{basePath}/e{num}.txt"};

            switch (num)
            {
                case 1:
                case 2:
                    Day_1.Runner.Run(args);
                    break;
                case 3:
                case 4:
                    Day_2.Runner.Run(args);
                    break;
                default:
                    Console.Error.WriteLine($"Solution for exercise {num} wasn't implemented yet.");
                    break;
            }
        }
    }
}