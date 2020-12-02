using System;
using System.IO;
using Utils;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var (ex, path) = Loader.ParseArgs(args);
            TextReader reader = (path == null) ? Console.In : new StreamReader(path);

            var input = Loader.LoadInput(reader);
            if (ex == 3)
            {
                new E3 {Input = input}.Solve();
            }
        }
    }
}