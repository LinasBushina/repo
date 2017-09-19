using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soroki
{
    class Program
    {
        static string soroki(string num)
        {
            if (num.Last() == '1') return num + " сорока";
            else if (num.Last() >= '2' && num.Last() <= '4')
            { return num + " сороки"; }
            else if (num.Last() >= '5' && num.Last() <= '9')
            { return num + " сорок"; }
            else return num + " сорок";
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(soroki(i.ToString()));
            }
        }
    }
}
