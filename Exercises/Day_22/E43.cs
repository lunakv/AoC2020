using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_22
{
    public class E43 : StringSolver
    {
        public override void Solve()
        {
            var sec = new Sectioner(Input);
            var deck1 = new Queue<int>();
            var deck2 = new Queue<int>();
            foreach (var line in sec.NextSection(1))
            {
                deck1.Enqueue(int.Parse(line));
            }

            foreach (var line in sec.NextSection(1))
            {
                deck2.Enqueue(int.Parse(line));
            }

            while (deck1.Count != 0 && deck2.Count != 0)
            {
                int one = deck1.Dequeue();
                int two = deck2.Dequeue();
                if (one > two)
                {
                    deck1.Enqueue(one);
                    deck1.Enqueue(two);
                }
                else
                {
                    deck2.Enqueue(two);
                    deck2.Enqueue(one);
                }
            }

            var winner = deck1.Count == 0 ? deck2 : deck1;
            long total = 0;
            while (winner.Count != 0)
            {
                total += winner.Count * winner.Dequeue();
            }

            Console.WriteLine($"The winner's score is {total}");
        }
    }
}