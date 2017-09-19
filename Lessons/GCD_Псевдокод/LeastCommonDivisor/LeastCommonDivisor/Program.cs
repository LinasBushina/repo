using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LeastCommonDivisor
{
    class Program
    {
        static int gcd_rec(int m, int n)
        {
            if (m == n) return m;
            if (m > n)
            { return gcd_rec(m - n, n); }
            else
            { return gcd_rec(m, n - m); }
        }

        static int gcd_rec2(int a, int b)
        { return (b == 0) ? a : gcd_rec2(b, a % b); }

        static int gcd_iter(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a + b;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine(gcd_iter(48, 28));
        }
    }
}
