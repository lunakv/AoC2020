using System;
using System.Collections.Generic;

namespace Exercises.Day_14
{
    public class E28 : E27_28
    {
        private ulong _oneMask;
        private ulong _xMask;
        
        protected override void ParseMask(string mask)
        {
            mask = mask.Trim();
            string oneMask = mask.Replace('X', '0');
            string xMask = mask.Replace('1', '0').Replace('X', '1');
            _oneMask = Convert.ToUInt64(oneMask, 2);
            _xMask = Convert.ToUInt64(xMask, 2);
        }

        protected override void WriteToMemory(string command, string argument)
        {
            ulong interAddress = ulong.Parse(command.Split('[', ']')[1]);
            ulong value = ulong.Parse(argument);
            interAddress = interAddress | _oneMask;

            var addresses = ResolveAllAddresses(interAddress);
            foreach (ulong address in addresses)
            {
                Memory[address] = value;
            }
        }

        private List<ulong> ResolveAllAddresses(ulong interAddress, int start = 0)
        {
            for (int i = start; i < MaskLength; i++)
            {
                if ((_xMask >> i) % 2 == 0) continue;
                ulong bit = 1UL << i;
                List<ulong> ret = ResolveAllAddresses(interAddress | bit, i + 1);
                ret.AddRange(ResolveAllAddresses(interAddress & ~bit, i + 1));
                return ret;
            }

            return new List<ulong> {interAddress};
        }
    }
}