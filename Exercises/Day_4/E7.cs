using System;
using System.Linq;

namespace Exercises.Day_4
{
    public class E7 : E7_8
    {
        public override void Solve()
        {
            var passports = GetPassports();
            int valid = passports.Count(passport => Required.SetEquals(passport.Keys));
            Console.WriteLine($"Found {valid} valid passports.");
        }
    }
}