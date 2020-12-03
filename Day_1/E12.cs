using System.Collections.Generic;
using Utils;

namespace Day_1
{
    public abstract class E12 : NumSolver
    {
        private List<int> _input = new List<int>();
        public int Sum { get; set; }

        public override List<int> Input
        {
            get => _input;
            set
            {
                _input = value;
                _input.Sort();
            }
        }
    }
}