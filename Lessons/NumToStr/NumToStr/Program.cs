using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToStr
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 123;
            string str = "";
            while (num > 0)
            {
                str = num % 10 + str;
                num /= 10;
            }
            Console.WriteLine(str);
        }
    }
}
