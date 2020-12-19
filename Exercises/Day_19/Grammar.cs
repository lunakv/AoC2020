using System.Collections.Generic;

namespace Exercises.Day_19
{
    public class Grammar
    {
        public NonTerminal? StartingSymbol { get; set; }
        public Dictionary<string, NonTerminal> NonTerminals { get; init; } = new();
        public Dictionary<string, Terminal> Terminals { get; init; } = new();
    }
}