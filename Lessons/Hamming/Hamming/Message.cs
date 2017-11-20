using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming
{
    abstract class Message
    {
        protected int[] bits;

        public int GetLength()
        { return bits.Length; }
        public int GetBit(int index)
        { return bits[index]; }
        protected bool IsPowerOfTwo(int x)
        { return (x & (x - 1)) == 0; }
        public override string ToString()
        { return string.Join("", bits); }
    }
}
