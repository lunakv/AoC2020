using System;
using Utils;

namespace Exercises.Day_9
{
    public class E18 : LongNumSolver
    {
        public override void Solve()
        {
            int invIndex = new E17 {Input = Input}.FindInvalidIndex();
            if (invIndex == -1)
            {
                Console.WriteLine("No invalid element found.");
                return;
            }
            long value = Input[invIndex];
            (int start, int end) = FindCorrectSum(value);
            if (start == -1)
            {
                Console.WriteLine("No sum for invalid element found.");
            }
            else
            {
                (long min, long max) = FindMinMax(start, end);
                Console.WriteLine($"The ends of the sum range add up to {min + max}");
            }
        }

        private (int, int) FindCorrectSum(long value)
        {
            for (int i = 0; i < Input.Count - 1; i++)
            {
                long sum = Input[i];
                for (int j = i + 1; j < Input.Count; j++)
                {
                    sum += Input[j];
                    if (sum > value)
                    {
                        break;
                    }
                    if (sum == value)
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        private (long, long) FindMinMax(int start, int end)
        {
            long min = Input[start];
            long max = Input[start];
            for (int i = start + 1; i <= end; i++)
            {
                if (Input[i] < min)
                {
                    min = Input[i];
                }
                else if (Input[i] > max)
                {
                    max = Input[i];
                }
            }

            return (min, max);
        }
    }
}