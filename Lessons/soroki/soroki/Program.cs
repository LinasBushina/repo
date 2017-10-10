using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soroki
{
    class Program
    {
        static string soroki(int num)
        {
            if (num % 100 >= 11 && num % 100 <= 14)
            { return num + " сырков"; }
            if (num % 10 == 1)
            { return num + " сырок"; }
            if (num % 10 >= 2 && num % 10 <= 4)
            { return num + " сырка"; }
            return num + " сырков";
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(soroki(i));
            }
        }
    }
}
