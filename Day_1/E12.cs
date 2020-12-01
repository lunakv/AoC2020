using System.Collections.Generic;
using Utils;

namespace Day_1
{
    public abstract class E12 : ISolver
    {
        public int Sum { get; set; }
        private List<int> _input = new List<int>();
        public List<int> Input
        {
            get => _input;
            set
            {
                _input = value;
                _input.Sort();
            }
        }

        public abstract void Solve();
    }

}