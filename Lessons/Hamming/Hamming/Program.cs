using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming
{
    class Program
    {
        static int summ (int a, int b, int c, int f)
        {
            if(a + b == 1 || a + b == 0)
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
        static void oldCode()
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
            int[] array1 = new int[N];
            array1[0] = summ(array[0], array[2], array[4], array[6]);
            array1[1] = summ(array[1], array[2], array[5], array[6]);
            array1[2] = summ(array[3], array[4], array[5], array[6]);
            string X = "array[2]+array[1]+array[0]";
            int numx = 0;
            for (int i = 0; i < X.Length; i++)
            {
                numx *= 10;
                numx += X[i] - '0';
            }
            int dec = Convert.ToInt32(X, 2);
            Console.WriteLine(dec);
        }

        static void Main(string[] args)
        {
            //DecodedMessage dm = new DecodedMessage("0100010000111101");
            //DecodedMessage dm = new DecodedMessage("0011111001001000");
            DecodedMessage dm = new DecodedMessage("0");
            CodedMessage cm = new CodedMessage(dm);
            Console.WriteLine(dm);
            Console.WriteLine(cm);
        }
    }
}
