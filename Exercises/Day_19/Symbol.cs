using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Day_19
{
    public abstract class Symbol
    {
        public string Name { get; init; } = "";
    }
    
    public class Terminal : Symbol
    { }

    public class NonTerminal : Symbol
    {
        public List<ReplaceRule> Rules { get; init; } = new();
    }

    public struct ReplaceRule
    {
        public List<Symbol> Symbols { get; init; }
        public int Count => Symbols.Count;
    }
}