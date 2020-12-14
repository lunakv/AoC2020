using System;
using System.Collections.Generic;
using Utils;

namespace Day_14
{
    public class E27 : E27_28
    {
        private ulong _zeroMask = ulong.MaxValue;
        private ulong _oneMask = 0;
        
        protected override void ParseMask(string mask)
        {
            string zeroMask = mask.Trim().Replace('X', '1');
            string oneMask = mask.Trim().Replace('X', '0');
            _zeroMask = Convert.ToUInt64(zeroMask, 2);
            _oneMask = Convert.ToUInt64(oneMask, 2);
        }

        protected override void WriteToMemory(string command, string argument)
        {
            uint address = uint.Parse(command.Split('[', ']')[1]);
            ulong value = ulong.Parse(argument);
            Memory[address] = ApplyMask(value);
        }

        private ulong ApplyMask(ulong value) => (value | _oneMask) & _zeroMask;
    }
}