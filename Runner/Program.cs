﻿using System;
using System.Diagnostics;
using Day_1;
using Day_10;
using Day_11;
using Day_12;
using Day_2;
using Day_3;
using Day_4;
using Day_5;
using Day_6;
using Day_7;
using Day_8;
using Day_9;
using Utils;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string basePath = args.Length > 0 ? args[0].TrimEnd('/', '\\') : ".";
            if (args.Length <= 1 || !int.TryParse(args[1], out int num))
            {
                Console.Write("Select exercise number: ");
                num = Loader.LoadNumber(Console.In);
            }
            var path = $"{basePath}/e{num}.txt";
            
            ISolver solver = num switch
            {
                1 => new E1 {Sum = 2020},
                2 => new E2 {Sum = 2020},
                3 => new E3(),
                4 => new E4(),
                5 => new E5 {Slope = (3, 1)},
                6 => new E6(),
                7 => new E7(),
                8 => new E8(),
                9 => new E9(),
                10 => new E10(),
                11 => new E11(),
                12 => new E12(),
                13 => new E13(),
                14 => new E14(),
                15 => new E15(),
                16 => new E16(),
                17 => new E17(),
                18 => new E18(),
                19 => new E19(),
                20 => new E20(),
                21 => new E21(),
                22 => new E22(),
                23 => new E23(),
                24 => new E24(),
                _ => throw new NotImplementedException($"Exercise {num} not yet implemented."),
            };
            
            var totalStopwatch = new Stopwatch();
            totalStopwatch.Start();
            switch (solver)
            {
                case NumSolver n:
                    var nInput = Loader.LoadNumbers(path);
                    n.Input = nInput;
                    break;
                case LongNumSolver l:
                    var lInput = Loader.LoadLongNumbers(path);
                    l.Input = lInput;
                    break;
                case StringSolver s:
                    var sInput = Loader.LoadInput(path);
                    s.Input = sInput;
                    break;
                default:
                    throw new ArgumentException("Unknown ISolver implementing class.");
            }

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