using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_19
{
    public abstract class E37_38 : StringSolver
    {

        protected Dictionary<int, Symbol> ParseGrammar(Sectioner sec)
        {
            var grammarStrings = new Dictionary<int, string>();
            var dependencies = new Dictionary<int, HashSet<int>>();

            foreach (string line in sec.NextSection())
            {
                string[] split = line.Split(':');
                int num = int.Parse(split[0]);
                grammarStrings[num] = split[1];
                dependencies[num] = ParseDependencies(split[1]);
            }

            return ParseGrammar(grammarStrings, dependencies);
        }
        
        private HashSet<int> ParseDependencies(string rule)
        {
            var ret = new HashSet<int>();
            foreach (var symbol in rule.Split(' '))
            {
                if (int.TryParse(symbol, out int num))
                    ret.Add(num);
            }
            
            return ret;
        }

        private Dictionary<int, Symbol> ParseGrammar(Dictionary<int, string> grammarStrings,
            Dictionary<int, HashSet<int>> dependencies)
        {
            var grammar = new Dictionary<int, Symbol>();
            foreach ((int num, string s) in grammarStrings)
            {
                ParseLine(num, grammarStrings, grammar, dependencies);
            }

            return grammar;
        }

        private void ParseLine(int num, Dictionary<int, string> grammarStrings, Dictionary<int, Symbol> grammar,
            Dictionary<int, HashSet<int>> dependencies)
        {
            if (dependencies.ContainsKey(num))
            {
                foreach (int dep in dependencies[num])
                {
                    if (!grammar.ContainsKey(dep))
                    {
                        ParseLine(dep, grammarStrings, grammar, dependencies);
                    }
                }
            }

            string[] options = grammarStrings[num].Split('|');
            var expansions = new List<List<Symbol>>();
            foreach (string option in options)
            {
                List<Symbol> rule = ParseRule(option, grammar);
                expansions.Add(rule);
            }

            grammar[num] = new Nonterminal {Expansions = expansions};
        }

        private List<Symbol> ParseRule(string str, Dictionary<int, Symbol> grammar)
        {
            var ret = new List<Symbol>();
            foreach (string symbol in str.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)) 
            {
                if (int.TryParse(symbol, out int num))
                {
                    ret.Add(grammar[num]);
                } 
                else if (symbol.StartsWith('"'))
                {
                    ret.Add(new Terminal {Value = symbol.Trim('"')});    
                }
                else
                {
                    throw new FormatException($"Unknown symbol: '{symbol}'.");
                }
            }

            return ret;
        }
    }
}