namespace Exercises.Day_8
{
    public class UsageLogger
    {
        private readonly int[] _usages;

        public UsageLogger(int size)
        {
            _usages = new int[size];
        }
        
        public void Log(int index, params string[] args)
        {
            _usages[index]++;
        }

        public int Count(int index) => _usages[index];
    }
}