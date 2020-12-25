using System;
using Utils;

namespace Exercises.Day_25
{
    public class E49 : NumSolver
    {
        private const int Subject = 7;
        private const int Modulus = 20201227;
        
        public override void Solve()
        {
            int card = Input[0];
            int door = Input[1];
            int cIt = BruteForce(card);
            int dIt = BruteForce(door);
            Console.WriteLine($"Card secret = {cIt}, Door secret = {dIt}");

            long key = Transform(card, dIt);
            Console.WriteLine($"The encryption key is {key}");

        }

        private int BruteForce(int password)
        {
            int i = 0;
            long value = 1;
            for (;value != password; i++)
            {
                value = (value * Subject) % Modulus;
            }

            return i;
        }

        private long Transform(int password, int iterations)
        {
            long value = 1;
            for (int i = 0; i < iterations; i++)
            {
                value = (value * password) % Modulus;
            }

            return value;
        }
    }
}