using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming
{
    class DecodedMessage : Message
    {
        public DecodedMessage(string msg)
        {
            this.bits = new int[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            { bits[i] = msg[i] == '1' ? 1 : 0; }
        }

        public DecodedMessage(CodedMessage msg)
        {
            string info = "";
            string code = "";
            for (int i = 1; i <= msg.GetLength(); i++)
            {
                if (!IsPowerOfTwo(i))
                { info += msg.GetBit(i - 1); }
                else
                { code += msg.GetBit(i - 1); }
            }
            CodedMessage newCoded = new CodedMessage(
                new DecodedMessage(info));

            string codedСode = "";
            for (int i = 1; i <= newCoded.GetLength(); i++)
            {
                if (IsPowerOfTwo(i))
                { codedСode += newCoded.GetBit(i - 1); }
            }

            int error = 0;
            for (int i = 1; i <= code.Length; i++)
            {
                if (code[i - 1] != codedСode[i - 1])
                { error += (int)Math.Pow(2, i - 1); }
            }

            bits = new int[info.Length + code.Length];
            for (int i = 1, inf = 0, cd = 0; i <= bits.Length; i++)
            {
                if (IsPowerOfTwo(i)) bits[i - 1] = code[cd++] - '0';
                else bits[i - 1] = info[inf++] - '0';
            }

            if (error != 0)
            {
                bits[error - 1] += 1;
                bits[error - 1] %= 2;
            }

            int[] newBits = new int[info.Length];
            for (int i = 1, inf = 0; i <= bits.Length; i++)
            { if (!IsPowerOfTwo(i)) newBits[inf++] = bits[i - 1]; }
            bits = newBits;
        }
    }
}
