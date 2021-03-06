﻿using System;
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
            int t = a;
            a = b;
            b = t;
        }

        static int FindKthLargest(int[] array, int K, int N)
        {
            int maxnum = -1;
            for (int i = 0; i < K; i++)
            {
                maxnum = array[0];
                int largestlocation = 0;
                for (int j = 1; j < N - i; j++)
                {
                    if (array[j] > maxnum)
                    {
                        maxnum = array[j];
                        largestlocation = j;
                    }
                }
                Swap(ref array[N - i - 1], ref array[largestlocation]);
            }
            return maxnum;
        }

        static int BinarySearch(int[] array, int K)
        {
            int start = 2;
            int end = 10;
            int middle = 0;
            while (start <= end)
            {
              middle = (start + end) / 2;
              switch (array[middle].CompareTo(K))
                {
                    case -1: start = middle + 1; break;
                    case 0: return middle; 
                    case 1: end = middle - 1; break;
                }
            
           }
            return -1;
        }

        static void Main(string[] args)
        {
            DateTime t = DateTime.Now;
            const int N = 20;
            const int K = 18;
            int[] array = new int[N];
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = rand.Next(1, 40);
                Console.Write("{0} ", array[i]);
            }
            int kth = FindKthLargest(array, K, N);
            Console.WriteLine("\nAfter: {0}-th = {1}", K, kth);
            for (int i = 0; i < N; i++)
            { Console.Write("{0} ", array[i]); }
            Console.WriteLine("\nSelection from 3 to 10:");
            for (int i = 2; i < 10; i++)
            { Console.Write("{0} ", array[i]); }
            Console.Write("\nPlease enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int index = -1;
            for (int i = 2; i < 10; i++)
            {
                if (array[i] == num)
                { index = i; break; }
            }
            //index = BinarySearch(array, num);
            if (index != -1)
            { Console.WriteLine("Position is {0}", index - 2); }
            else Console.WriteLine("Number was not finded");
            TimeSpan time = DateTime.Now - t;
            Console.WriteLine("Time is {0}", time);
        }
    }
}
