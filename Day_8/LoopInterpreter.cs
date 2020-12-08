using System;
using System.Collections.Generic;

namespace Day_8
{
    public class LoopInterpreter
    {
        private readonly List<Operation> _instructions;
        private int _acc = 0;
        private int _sp = 0;

        public LoopInterpreter(IParser parser, List<string> input)
        {
            _instructions = parser.ParseInput(input);
        }

        public LoopInterpreter(List<Operation> instructions)
        {
            _instructions = instructions;
        }

        public int Run()
        {
            var logger = new UsageLogger(_instructions.Count);
            while (_sp < _instructions.Count && logger.Count(_sp) == 0)
            {
                logger.Log(_sp);
                _instructions[_sp].Run(ref _acc, ref _sp);
                _sp++;
            }

            return _acc;
        }

        public bool ReachedEnd => _sp >= _instructions.Count;
    }
}