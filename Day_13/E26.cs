using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;

namespace Day_13
{
    public class E26 : StringSolver
    {
        public override void Solve()
        {
            var buses = ParseBuses(Input[1]);
            (BigInteger n, BigInteger rem) = ChineseRemainderTheorem(buses);
            Console.WriteLine($"The first such time is {rem}");
            Console.WriteLine($"The modulus is {n}");
        }

        private List<(int, int)> ParseBuses(string line)
        {
            var ret = new List<(int, int)>();
            var split = line.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out int num))
                {
                    int rem = (num - i) % num;
                    if (rem < 0) rem += num;
                    ret.Add((num, rem));
                }
            }

            return ret;
        }

        private (BigInteger, BigInteger) FindBezoutCoefficients(BigInteger a, BigInteger b)
        {
            (BigInteger oldR, BigInteger r) = (a, b);
            (BigInteger oldS, BigInteger s) = (1, 0);
            (BigInteger oldT, BigInteger t) = (0, 1);

            while (r != 0)
            {
                BigInteger quotient = oldR / r;
                (oldR, r) = (r, oldR - quotient * r);
                (oldS, s) = (s, oldS - quotient * s);
                (oldT, t) = (t, oldT - quotient * t);
            }

            return (oldS, oldT);
        }

        private (BigInteger, BigInteger) ChineseRemainderTheorem(List<(int, int)> numbers)
        {
            (BigInteger n1, BigInteger rem1) = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                (BigInteger n2, BigInteger rem2) = numbers[i];
                (BigInteger m1, BigInteger m2) = FindBezoutCoefficients(n1, n2);
                BigInteger newN = n1 * n2;
                BigInteger x = (rem1 * n2 * m2 + rem2 * n1 * m1) % newN;
                if (x < 0) x += newN;
                (n1, rem1) = (newN, x);
            }

            return (n1, rem1);
        }
    }
}