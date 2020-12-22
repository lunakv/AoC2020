using System.Collections.Generic;

namespace Utils
{
    public class Sectioner
    {
        private List<string> _input;
        private int _start;

        public Sectioner(List<string> input)
        {
            _input = input;
        }

        public IEnumerable<string> NextSection(int skip = 0)
        {
            _start += skip;
            for (int i = _start; i < _input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(_input[i]))
                {
                    _start = i + 1;
                    yield break;
                }
                yield return _input[i];
            }
        }
    }
}