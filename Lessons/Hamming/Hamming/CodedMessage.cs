using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming
{
    class CodedMessage : Message
    {
        public CodedMessage(DecodedMessage msg)
        {
            int len = msg.GetLength();
            for (int i = 1; i <= len; i++)
            { if (IsPowerOfTwo(i)) len++; }
            bits = new int[len];

            for (int i = 1, from = 0; i <= len; i++)
            {
                if (IsPowerOfTwo(i))
                { bits[i - 1] = 0; }
                else
                {
                    bits[i - 1] = msg.GetBit(from++);
                    string bitStr = Convert.ToString(i, 2);
                    for (int k = 0; k < bitStr.Length; k++)
                    {
                        if (bitStr[k] == '0') continue;
                        int power = bitStr.Length - k - 1;
                        int index = (int)Math.Pow(2, power) - 1;
                        bits[index] += bits[i - 1];
                        bits[index] %= 2;
                    }
                }
            }
        }

        public void MakeFault(int index)
        { bits[index] ^= 1; }
    }
}
