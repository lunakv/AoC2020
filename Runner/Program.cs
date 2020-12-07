using System;
using Day_1;
using Day_2;
using Day_3;
using Day_4;
using Day_5;
using Day_6;
using Day_7;
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
                _ => throw new NotImplementedException($"Exercise {num} not yet implemented."),
            };
            
            switch (solver)
            {
                case NumSolver n:
                    var nInput = Loader.LoadNumbers(path);
                    n.Input = nInput;
                    n.Solve();
                    break;
                case StringSolver s:
                    var sInput = Loader.LoadInput(path);
                    s.Input = sInput;
                    s.Solve();
                    break;
                default:
                    throw new ArgumentException("Unknown ISolver implementing class.");
            }
        }
    }
}