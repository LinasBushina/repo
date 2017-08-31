using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int n = 4;
        //    Console.WriteLine(factorial_rec_tail(n));
        //}

        //static int factorial_imp(int n)
        //{
        //    int res = 1;
        //    for (int i = 2; i <= n; i++)
        //    { res *= i; }
        //    return res;
        //}

        //static int factorial_rec(int n)
        //{
        //    if (n < 2) return 1;
        //    return factorial_rec(n - 1) * n;
        //}

        //static int factorial_rec_tail(int n, int acc = 1)
        //{
        //    if (n < 2) return acc;
        //    return factorial_rec_tail(n - 1, n * acc);
        //}

        static void Main(string[] args)
        {
            int[] array = { 8, 6, 5, 6, 8, 9, 9, 7, 7 };
            int unicdigit = 0;
            for (int i = 0; i < array.Length; i++)
            { unicdigit ^= array[i]; }
            Console.WriteLine(unicdigit);
        }
    }
}
