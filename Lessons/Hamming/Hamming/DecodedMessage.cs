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
    }
}
