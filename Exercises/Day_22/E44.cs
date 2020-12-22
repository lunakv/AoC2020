using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_22
{
    public class E44 : StringSolver
    {
        public override void Solve()
        {
            var sec = new Sectioner(Input);
            var deck1 = new Queue<int>();
            foreach (string line in sec.NextSection(1))
            {
                deck1.Enqueue(int.Parse(line));
            }

            var deck2 = new Queue<int>();
            foreach (string line in sec.NextSection(1))
            {
                deck2.Enqueue(int.Parse(line));
            }

            var winner = RecursiveCombat(deck1, deck2) ? deck2 : deck1;
            long total = 0;
            while (winner.Count != 0)
            {
                Console.Write($"{winner.Peek()} ");
                total += winner.Count * winner.Dequeue();
            }

            Console.WriteLine();
            Console.WriteLine($"The recursive combat score is {total}");
        }

        // false for deck1 win, true for deck2 win
        private bool RecursiveCombat(Queue<int> deck1, Queue<int> deck2)
        {
            var previous = new List<(Queue<int>, Queue<int>)>();
            while (deck1.Count != 0 && deck2.Count != 0)
            {
                // PrintState(deck1, deck2);
                // if we cycle, player 1 wins
                if (previous.Any(p => DeepEqual(p.Item1, deck1) && DeepEqual(p.Item2, deck2))) 
                    return false;
                previous.Add((Clone(deck1), Clone(deck2)));

                int card1 = deck1.Dequeue();
                int card2 = deck2.Dequeue();
                
                // if one deck doesn't have enough cards left, higher card wins
                if (card1 > deck1.Count || card2 > deck2.Count)
                {
                    if (card1 > card2)
                    {
                        deck1.Enqueue(card1);
                        deck1.Enqueue(card2);
                    }
                    else
                    {
                        deck2.Enqueue(card2);
                        deck2.Enqueue(card1);
                    }
                }
                // otherwise we recurse
                else
                {
                    if (RecursiveCombat(Clone(deck1, card1), Clone(deck2, card2)))
                    {
                        deck2.Enqueue(card2);
                        deck2.Enqueue(card1);
                    }
                    else
                    {
                        deck1.Enqueue(card1);
                        deck1.Enqueue(card2);
                    }
                }
            }

            return deck1.Count == 0;
        }

        private bool DeepEqual(Queue<int> one, Queue<int> two)
        {
            if (one.Count != two.Count) return false;
            bool same = true;
            for (int i = 0; i < one.Count; i++)
            {
                int a = one.Dequeue();
                int b = two.Dequeue();
                one.Enqueue(a);
                two.Enqueue(b);
                if (a != b) same = false;
            }

            return same;
        }

        private Queue<int> Clone(Queue<int> q, int count)
        {
            var ret = new Queue<int>();
            foreach (int i in q)
            {
                if (count-- == 0) break;
                ret.Enqueue(i);
            }

            return ret;
        }

        private Queue<int> Clone(Queue<int> q) => Clone(q, q.Count);

        private void PrintState(Queue<int> d1, Queue<int> d2)
        {
            Console.Write("Player 1 deck: ");
            foreach (int i in d1)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.Write("Player 2 deck: ");
            foreach (int i in d2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}