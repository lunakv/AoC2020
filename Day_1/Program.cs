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
            if (args.Length == 0 || !int.TryParse(args[0], out int ex))
            {
                Console.Error.WriteLine("First argument must be number of exercise (1 or 2).");
                return;
            }
            if (ex != 1 && ex != 2)
            {
                Console.Error.WriteLine("First argument must be 1 or 2");
            }
            
            var reader = (args.Length > 1 ? new StreamReader(args[1]) : Console.In);
            List<int> input = Loader.LoadNumbers(reader);
            
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