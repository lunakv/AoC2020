using System;

namespace Day_1
{
    public class E1 : E12
    {
        public override void Solve()
        {
            var pair = FindPair();
            if (pair == null)
            {
                Console.WriteLine("No numbers that add up to 2020 found.");
            }
            else
            {
                Console.WriteLine($"Numbers are {pair.Item1} and {pair.Item2}");
                Console.WriteLine($"Their product is {pair.Item1 * pair.Item1}");
            }
        }

        public Tuple<int, int>? FindPair(int start = 0)
        {
            int front = start;
            int back = Input.Count - 1;
            while (front < back)
            {
                int a = Input[front];
                int b = Input[back];
                if (a + b == Sum)
                    return new Tuple<int, int>(a, b);
                if (a + b > Sum)
                    back--;
                else
                    front++;
            }

            return null;
        }
    }
}