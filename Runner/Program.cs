﻿using System;
using Utils;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string basePath = args.Length > 0 ? args[0].TrimEnd('/', '\\') : ".";
            int num;
            if (args.Length <= 1 || !int.TryParse(args[1], out num))
            {
                Console.Write("Select exercise number: ");
                num = Loader.LoadNumber(Console.In);
            }

            args = new[] {num.ToString(), $"{basePath}/e{num}.txt"};

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
                case 5:
                case 6:
                    Day_3.Runner.Run(args);
                    break;
                case 7:
                case 8:
                    Day_4.Runner.Run(args);
                    break;
                case 9:
                case 10:
                    Day_5.Runner.Run(args);
                    break;
                case 11:
                case 12:
                    Day_6.Runner.Run(args);
                    break;
                default:
                    Console.Error.WriteLine($"Solution for exercise {num} wasn't implemented yet.");
                    break;
            }
        }
    }
}