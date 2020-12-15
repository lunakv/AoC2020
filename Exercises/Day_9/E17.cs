using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_9
{
    public class E17 : LongNumSolver
    {
        private const int PreambleSize = 25;
        private readonly List<long> _sortedBuffer = new List<long>(PreambleSize);
        private readonly Queue<long> _buffer = new Queue<long>(PreambleSize);
        
        public override void Solve()
        {
            int invIndex = FindInvalidIndex();
            Console.WriteLine(invIndex == -1
                ? "No invalid elements found."
                : $"The first invalid number is {Input[invIndex]}.");
        }

        public int FindInvalidIndex()
        {
            LoadPreamble();
            for (int i = PreambleSize; i < Input.Count; i++)
            {
                long next = Input[i];
                if (!IsValidSum(next))
                {
                    return i;
                }
                
                AddElement(next);
            }

            return -1;
        }

        private void LoadPreamble()
        {
            for (int i = 0; i < PreambleSize; i++)
            {
                _sortedBuffer.Add(Input[i]);
                _buffer.Enqueue(Input[i]);
            }

            _sortedBuffer.Sort();
        }

        private bool IsValidSum(long value)
        {
            int i = 0;
            int j = PreambleSize - 1;
            while (i < j)
            {
                long sum = _sortedBuffer[i] + _sortedBuffer[j];
                if (sum < value)
                    i++;
                else if (sum > value)
                    j--;
                else
                    return true;
            }

            return false;
        }

        private void AddElement(long value)
        {
            long gone = _buffer.Dequeue();
            _buffer.Enqueue(value);
            _sortedBuffer.Remove(gone);
            _sortedBuffer.Add(value);
            _sortedBuffer.Sort();
        }
    }
}