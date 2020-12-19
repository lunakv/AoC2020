using System;
using System.Linq;
using Utils;

namespace Exercises.Day_19
{
    public class E38 : E37_38
    {
        public override void Solve()
        {
            var sec = new Sectioner(Input);
            var grammar = ParseGrammar(sec);
            grammar.StartingSymbol = grammar.NonTerminals["0"];
            var nt = grammar.NonTerminals;
            nt["8"].Rules.Add(new ReplaceRule {Symbols = new() {nt["42"], nt["8"]}});
            nt["11"].Rules.Add(new ReplaceRule {Symbols = new() {nt["42"], nt["11"], nt["31"]}});
            
            var parser = new EarleyParser(grammar.StartingSymbol);

            int total = sec.NextSection().Count(line => parser.Recognizes(line));
            Console.WriteLine($"Parser recognizes {total} lines from input.");
        }
    }
}