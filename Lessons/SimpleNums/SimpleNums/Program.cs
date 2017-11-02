using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 9;
            bool flag = true;
            for (int i = 2; i < n; i++)
            {
                for (int j = 2; j < n; j++)
                {
                    if (i % j == 0)
                    {
                        Console.WriteLine(i);
                        flag = false;
                    }
                }
            }
        }
    }
}
