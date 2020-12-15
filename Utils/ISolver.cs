using System.Collections.Generic;

namespace Utils
{
    public interface ISolver
    {
        void Solve();
    }

    public abstract class NumSolver : ISolver
    {
        public List<int> Input { get; set; } = new();
        public abstract void Solve();
    }

    public abstract class StringSolver : ISolver
    {
        public List<string> Input { get; set; } = new();
        public abstract void Solve();
    }

    public abstract class LongNumSolver : ISolver
    {
        public List<long> Input { get; set; } = new();
        public abstract void Solve();
    }
}