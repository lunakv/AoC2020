using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_19
{
    public class E37 : E37_38
    {
        public override void Solve()
        {
            var sec = new Sectioner(Input);
            var grammar = ParseGrammar(sec);
            grammar.StartingSymbol = grammar.NonTerminals["0"];
            var parser = new EarleyParser(grammar.StartingSymbol);

            int total = sec.NextSection().Count(line => parser.Recognizes(line));
            Console.WriteLine($"Parser accepts {total} lines from input.");
        }
    }
}