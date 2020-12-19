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
            Dictionary<int, Symbol> grammar = ParseGrammar(sec);
            HashSet<string> language = grammar[0].FindMatchingStrings();
            
            /*
            Console.WriteLine("Grammar of this language: ");
            foreach (string s in grammar[0].FindMatchingStrings())
            {
                Console.WriteLine(s);
            }
            /**/

            int total = sec.NextSection().Count(line => language.Contains(line));
            Console.WriteLine($"Total number of matching strings is {total}");
        }
    }
}