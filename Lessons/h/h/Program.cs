using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h
{
    class Program
    {
        static int summ(int a, int b, int c, int f)
        {
            if (a + b == 1 || a + b == 0)
            {
                a = a + b;
            }
            else { a = 0; }
            if (a + c == 1 || a + c == 0)
            {
                a = a + c;
            }
            else { a = 0; }
            if (a + f == 1 || a + f == 0)
            {
                a = a + f;
            }
            else { a = 0; }
            return a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Put the quantity of numbers: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[N];
            Console.WriteLine("Put numbers: ");
            for (int i = 0; i < N; i++)
            {
                if (array[i] == 0 || array[i] == 1)
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Error!");
                    return;
                }
            }
            for (int i = 0; i < N; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
            int[] array1 = new int[N];
            array1[0] = summ(array[0], array[2], array[4], array[6]);
            array1[1] = summ(array[1], array[2], array[5], array[6]);
            array1[2] = summ(array[3], array[4], array[5], array[6]);
            string X = array1[2].ToString();
            string X1 = X + array1[1].ToString();
            string X3 = X1 + array1[0].ToString();
            int C1 = Convert.ToInt32(X3, 2);
            Console.WriteLine("X = "+X3);
            Console.WriteLine(C1);
            for (int i = 0; i < N; i++)
            {
                if((i+1) == C1)
                {
                    if(array[i] == 1)
                    {
                        array[i] = 0;
                    }
                    if (array[i] == 0)
                    {
                        array[i] = 1;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                Console.Write(array[i]);
            }

        }
    }
}
