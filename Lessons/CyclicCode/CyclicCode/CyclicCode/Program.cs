using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        private static void Test1()
        {
            Console.WriteLine(CyclicAlgorithm.Calc(
                new Polynomial("1001"), new Polynomial("1011")));
        }

        private static void Test2()
        {
            Console.WriteLine(CyclicAlgorithm.Calc(
                new Polynomial("10101"), new Polynomial("1101")));
        }
    }
}
