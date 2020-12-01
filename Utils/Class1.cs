using System;
using System.Collections.Generic;
using System.IO;

namespace Utils
{
    public static class Loader
    {
        public static List<int> LoadNumbers(TextReader reader)
        {
            var ret = new List<int>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                ret.Add(int.Parse(line));
            }

            return ret;
        }
    }

    public interface ISolver
    {
        void Solve();
    }
}