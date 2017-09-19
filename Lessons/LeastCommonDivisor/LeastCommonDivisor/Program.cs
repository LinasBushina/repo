using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastCommonDivisor
{
    class Program
    {
        static int func(int m, int n)
        {
            while (m != n)
            {
                if (m > n)
                {
                    return func(m-n, n);
                }
                else
                {
                   return func(m, n - m);
                }
            }
            return m;
        }
        
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            int n = Convert.ToInt32(str1);
            int m = Convert.ToInt32(str2);
            m = func(m, n);
            Console.WriteLine(m);
        }
    }
}
