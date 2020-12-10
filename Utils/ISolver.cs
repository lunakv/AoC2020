using System.Collections.Generic;

namespace Utils
{
    public interface ISolver
    {
        void Solve();
    }

    public abstract class NumSolver : ISolver
    {
        public virtual List<int> Input { get; set; } = new List<int>();
        public abstract void Solve();
    }

    public abstract class StringSolver : ISolver
    {
        public virtual List<string> Input { get; set; } = new List<string>();
        public abstract void Solve();
    }

    public abstract class LongNumSolver : ISolver
    {
        public virtual List<long> Input { get; set; } = new List<long>();
        public abstract void Solve();
    }
}