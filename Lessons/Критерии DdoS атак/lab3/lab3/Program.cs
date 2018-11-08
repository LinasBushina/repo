using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix("matrix3.txt");
            Console.WriteLine(m.Wald());
            Console.WriteLine(m.Savage());
            Console.WriteLine(m.Hurwitz());
            Console.WriteLine(m.Laplace());
        }
    }
}
