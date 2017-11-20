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
            int msgLen = msg.GetLength();
            double log = Math.Log(msgLen, 2.0f);
            int controlCount = (int)log + 1;
            int newLen = msgLen + controlCount;
            bits = new int[newLen];
            
            
            for (int i = 1, from = 0, contrl = 0; i <= newLen; i++)
            {
                if (IsPowerOfTwo(i) && contrl < controlCount)
                {
                    bits[i - 1] = 0;
                    contrl++;
                }
                else
                {
                    bits[i - 1] = msg.GetBit(from++);
                    string bitStr = Convert.ToString(i, 2);
                    for (int k = 0; k < bitStr.Length; k++)
                    {
                        if (bitStr[k] == '0') continue;
                        int power = bitStr.Length - k - 1;
                        int index = (int)Math.Pow(2, power) - 1;
                        bits[index] += bits[index];
                        bits[index] %= 2;
                    }
                }
            }
        }
    }
}
