using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Day_19
{
    public abstract class Symbol
    {
        public abstract HashSet<string> FindMatchingStrings();
    }

    public class Nonterminal : Symbol
    {
        public List<List<Symbol>> Expansions { get; init; }= new();
        private HashSet<string>? _matchingStrings;

        public override HashSet<string> FindMatchingStrings()
        {
            if (_matchingStrings is not null) return _matchingStrings;
            
            var ret = new HashSet<string>();
            foreach (var rule in Expansions)
            {
                IEnumerable<string>? ruleStrings = null;
                foreach (Symbol symbol in rule)
                {
                    var symbolStrings = symbol.FindMatchingStrings();
                    if (ruleStrings is null) ruleStrings = symbolStrings;
                    else
                        ruleStrings =
                            from ruleString in ruleStrings
                            from symbolString in symbolStrings
                            select ruleString + symbolString;

                }

                foreach (var ruleString in ruleStrings ?? new string[]{})
                {
                    ret.Add(ruleString);
                }
            }
            
            _matchingStrings = ret;
            return ret;
        }
    }

    public class Terminal : Symbol
    {
        public string Value { get; init; } = "";

        public override HashSet<string> FindMatchingStrings() => new() {Value};
    }
        
        
}