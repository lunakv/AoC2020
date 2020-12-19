using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_19
{

    public abstract class E37_38 : StringSolver
    {

        protected Grammar ParseGrammar(Sectioner sec)
        {
            var grammar = new Grammar();
            
            foreach (string line in sec.NextSection())
            {
                string[] split = line.Split(':');
                string name = split[0];
                string ruleset = split[1];
                grammar.NonTerminals.TryAdd(name, new NonTerminal {Name = name});
                split = ruleset.Split('|');
                foreach (string rule in split)
                {
                    AddRuleToGrammar(grammar, name, rule);
                }
            }

            //PrintGrammar(grammar.NonTerminals);
            return grammar;
        }

        private void AddRuleToGrammar(Grammar grammar, string startSymbol, string ruleString)
        {
            string[] split =
                ruleString.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var rule = new ReplaceRule {Symbols = new()};
            foreach (string symbol in split)
            {
                if (symbol.StartsWith('"'))
                {
                    string term = symbol.Trim('"');
                    grammar.Terminals.TryAdd(term, new Terminal {Name = term});
                    rule.Symbols.Add(grammar.Terminals[term]);
                }
                else
                {
                    grammar.NonTerminals.TryAdd(symbol, new NonTerminal {Name = symbol});
                    rule.Symbols.Add(grammar.NonTerminals[symbol]);
                }
            }

            grammar.NonTerminals[startSymbol].Rules.Add(rule);
        }

        private void PrintGrammar(Dictionary<string, NonTerminal> grammar)
        {
            foreach ((string key, NonTerminal nt) in grammar)
            {
                Console.Write($"{key} -> ");
                foreach (ReplaceRule rule in nt.Rules)
                {
                    foreach (Symbol s in rule.Symbols)
                    {
                        Console.Write($"{s.Name} ");
                    }

                    Console.Write("| ");
                }

                Console.WriteLine();
            }
        }
    }
}