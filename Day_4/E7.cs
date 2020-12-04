using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_4
{
    public class E7 : E78
    {
        public override void Solve()
        {
            int valid = 0;
            var passports = GetPassports();
            foreach (var passport in passports)
            {
                if (Required.SetEquals(passport.Keys))
                    valid++;
            }
            Console.WriteLine($"Found {valid} valid passports.");
        }
    }
}