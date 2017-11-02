﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xafmanprogram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Put the quantity of numbers: ");
            int N = Convert.ToInt32(Console.ReadLine());
            double[] array_x = new double [N];
            Console.WriteLine("Put numbers: ");
            for(int i = 0; i<N; i++)
            {
                array_x[i] = Convert.ToDouble(Console.ReadLine());
                if( array_x[i] >= 1)
                {
                    Console.WriteLine("Error!");
                }
            }
            double[] array_x_sort = new double[N];
            for (int i = 0; i < N; i++ )
            {
                array_x_sort[i] = array_x[i];
            }
                Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < array_x_sort.Length - 1 - i; j++)
                {
                    if (array_x_sort[j] > array_x_sort[j + 1])
                    {
                        double t = array_x_sort[j];
                        array_x_sort[j] = array_x_sort[j + 1];
                        array_x_sort[j + 1] = t;
                    }

                }
            }
            for (int i = 0; i < array_x.Length; i++)
            {
                Console.Write(array_x_sort[i] + " ");
            }
            Console.WriteLine();
            double sum = 0;
            int k = 0;
            double[] array_sum = new double[N];
            for (int i = array_x_sort.Length - 1; i > 0; i--)
            {
                sum = array_x_sort[i] + array_x_sort[array_x_sort.Length - i - 1];
                array_sum[i] = sum;
                array_x_sort[i] = sum;
                k++;
            }
            Console.WriteLine(sum);
            for (int i = 0; i < k; i++)
            {
                Console.Write(array_sum[i] + " ");
            }
        }
    }
}