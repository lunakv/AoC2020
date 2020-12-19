using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Exercises.Day_8;

namespace Exercises.Day_19
{
    public class EarleyParser
    {
        private readonly NonTerminal _start;

        public EarleyParser(NonTerminal start)
        {
            _start = start;
        }

        public bool Recognizes(string word)
        {
            var positionArray = new List<List<EarleyItem>>();
            positionArray.Add(new List<EarleyItem>());
            foreach (ReplaceRule rule in _start.Rules)
            {
                positionArray[0].Add(new EarleyItem
                {
                    ReplacedSymbol = _start, Rule = rule, StartPosition = 0, CurrentPosition = 0,
                });
            }

            Parse(word, positionArray);
            // PrintTable(positionArray);
            return positionArray.Count > word.Length && positionArray[word.Length].Any(
                item => item.ReplacedSymbol == _start && item.Completed && item.StartPosition == 0);
        }

        private void Parse(string word, List<List<EarleyItem>> positionArray)
        {
            for (int i = 0; i < positionArray.Count; i++)
            {
                for (int j = 0; j < positionArray[i].Count; j++)
                {
                    EarleyItem item = positionArray[i][j];
                    if (item.Completed)
                    {
                        Complete(positionArray, i, item);
                    }
                    else if (item.CurrentSymbol is NonTerminal nt)
                    {
                        Predict(positionArray, i, nt);
                    }
                    else if (i < word.Length) // next symbol is a terminal, so we scan if able
                    {
                        if (word[i].ToString() == item.CurrentSymbol.Name)
                        {
                            EarleyItem newItem = item with {CurrentPosition = item.CurrentPosition + 1};
                            AddToPosition(positionArray, i + 1, newItem);
                        }
                    }
                }
            }
        }

        private void Complete(List<List<EarleyItem>> positionArray, int position, EarleyItem item)
        {
            int startPositon = item.StartPosition;
            foreach (EarleyItem starter in positionArray[startPositon])
            {
                if (!starter.Completed && starter.CurrentSymbol == item.ReplacedSymbol)
                {
                    AddToPosition(positionArray, position, starter with {CurrentPosition = starter.CurrentPosition + 1});
                }
            }
        }

        private void Predict(List<List<EarleyItem>> positionArray, int position, NonTerminal replacedSymbol)
        {
            foreach (ReplaceRule rule in replacedSymbol.Rules)
            {
                AddToPosition(positionArray, position,
                    new EarleyItem
                    {
                        ReplacedSymbol = replacedSymbol, Rule = rule, StartPosition = position, CurrentPosition = 0
                        
                    });
            }
        }

        private void AddToPosition(List<List<EarleyItem>> positionArray, int position, EarleyItem item)
        {
            while (positionArray.Count <= position)
                positionArray.Add(new());

            if (!positionArray[position].Contains(item))
            {
                positionArray[position].Add(item);
            }
        }

        private void PrintTable(List<List<EarleyItem>> table)
        {
            for (int i = 0; i < table.Count; i++)
            {
                Console.WriteLine($"S({i}):");
                foreach (EarleyItem item in table[i])
                {
                    Console.Write($"{item.ReplacedSymbol?.Name} -> ");
                    for(int j = 0; j < item.Rule.Symbols.Count; j++)
                    {
                        Symbol symbol = item.Rule.Symbols[j];
                        if (j == item.CurrentPosition) Console.Write("|");
                        Console.Write(symbol.Name + " ");
                    }

                    Console.WriteLine($"\t\t(start={item.StartPosition}, curr={item.CurrentPosition})");
                }

                Console.WriteLine();
            }
        }

        private record EarleyItem
        {
            public Symbol? ReplacedSymbol { get; init; }
            public ReplaceRule Rule { get; init; }
            public int StartPosition { get; init; }
            public int CurrentPosition { get; init; }

            public Symbol CurrentSymbol => Rule.Symbols[CurrentPosition];
            public bool Completed => CurrentPosition == Rule.Count;
        }
    }
}