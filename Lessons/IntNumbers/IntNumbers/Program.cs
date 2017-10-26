using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntNumbers
{
    class Program
    {
        static void SortMinMax(int a, int b, int c, int d)
        {
            Console.WriteLine("{0} ,{1} ,{2} ,{3}", a, b, c, d);
            if (a > b)
            {
                int t = a;
                a = b;
                b = t;
            }
            if (b > c)
            {
                int t = b;
                b = c;
                c = t;
            }
            if (c > d)
            {
                int t = b;
                b = d;
                d = t;
            }
            if (a > b)
            {
                int t = a;
                a = b;
                b = t;
            }
            if (a > c)
            {
                int t = a;
                a = c;
                c = t;
            }
            if (a > b)
            {
                int t = a;
                a = b;
                b = t;
            }

            Console.WriteLine("{0} ,{1} ,{2} ,{3} ", a, b, c, d);
        }
        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }

                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void MinMax()
        {
            int[] array = { 3, 1, 2 };
            int max = array[0];
            int min = array[0];
            for (int i = 0; i < 3; i++)
            {
                if (array[i] >= max)
                {
                    max = array[i];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (array[i] <= min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            for (int i = 0; i < 3; i++)
            {
                if (array[i] != min && array[i] != max)
                    Console.WriteLine(array[i]);
            }
        }

        static void Main(string[] args)
        {
            //SortMinMax(1, 2, 3, 4);
            //Console.WriteLine();
            //SortMinMax(1, 3, 2, 4);
            //Console.WriteLine();
            //SortMinMax(2, 1, 3, 4);
            //Console.WriteLine();
            //SortMinMax(2, 3, 1, 4);
            //Console.WriteLine();
            //SortMinMax(3, 1, 2, 4);
            //Console.WriteLine();
            //SortMinMax(3, 2, 1, 4);
            //Console.WriteLine();
            //SortMinMax(1, 1, 1, 4);
            //Console.WriteLine();
            //SortMinMax(1, 1, 2, 4);
            //Console.WriteLine();
            //SortMinMax(1, 2, 1, 4);
            //Console.WriteLine();
            //SortMinMax(2, 1, 1, 4);
            //Console.WriteLine();
            //SortMinMax(2, 1, 2, 4);
            int[] array = { 5, 4, 3, 2, 1 };
            BubbleSort(array);
        }
    }
}
