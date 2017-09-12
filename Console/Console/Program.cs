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
            string str = "123";
            int number = 0;
            for (int i = 0; i < str.Length; i++)
            {
                number = number * 10 + str[i] - 0x30;
            }
            System.Console.WriteLine(number);
        }
    }
}
