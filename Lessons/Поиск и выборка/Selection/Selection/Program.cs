using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static void FindKthLargest(ref int[] array, int N)
        {
            int k1 = 3; // порядковый номер по ведичине требуемого элемента 
            for (int i = 0; i < 3; i++)
            {
                int maxnum = array[1];
                int largestlocation = 1;
                for (int j = 2; i < 20 - (i - 1); i++)
                {
                    if (array[j] > maxnum)
                    {
                        maxnum = array[j];
                        largestlocation = j;
                    }
                }
                Swap(ref array[20 - (i - 1)], ref array[largestlocation]);
            }
        }

        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rand = new Random();
            int N = 20;
            for(int i = 0; i<20; i++)
            {
                array[i] = rand.Next(1, 40);
                Console.WriteLine(array[i]);
            }
            FindKthLargest(ref array, N);
            Console.WriteLine("After: ");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
