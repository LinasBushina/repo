using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "011";
            int num = 0;
            for (int i = 0; i < str.Length; i++)
            {
                num *= 10;
                num += str[i] - '0';
            }
            System.Console.WriteLine(num);
        }
    }
}
