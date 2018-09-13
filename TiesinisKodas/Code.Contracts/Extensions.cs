using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Contracts
{
    public static class Extensions
    {
        public static byte[] ToBytes(this BitArray bits)
        {
            int nrOfBytes = bits.Count / 8;
            bits.Length = nrOfBytes * 8;
            var result = new byte[nrOfBytes];
            bits.CopyTo(result, 0);
            return result;
        }

        public static string ToText(this BitArray bits)
        {
            string result = string.Empty;
            foreach(bool bit in bits)
            {
                result += bit.ToText();
            }
            return result;  
        }

        public static string ToText(this bool bit)
        {
            if (bit)
                return "1";
            else
                return "0";
        }
    }
}
