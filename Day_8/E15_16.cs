using System;
using Utils;

namespace Day_8
{
    public class E15 : StringSolver
    {
        public override void Solve()
        {
            var parser = new Parser();
            var runner = new LoopInterpreter(parser, Input);
            int result = runner.Run();

            Console.WriteLine($"Accumulator was at {result} before loop was found.");
        }
    }
    
    public class E16 : StringSolver
    {
        public override void Solve()
        {
            var parser = new Parser();
            var runner = new CorruptionInterpreter(parser, Input);
            int result = runner.Run();

            Console.WriteLine($"Accumulator after fixed run is at {result}.");
        }
    }
}