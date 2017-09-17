using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soroki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Put down number:");
            string numberreal = Console.ReadLine();
            string number = numberreal.Trim();
            if(number.Last() == '1')
            {
                Console.WriteLine(number + " сорока");
            }
            else if(number.Last()>= '2' && number.Last() <= '4')
            {
                Console.WriteLine(number + " сороки");
            }
            else if(number.Last()>= '5' && number.Last() <= '9')
            {
                Console.WriteLine(number + " сорок");
            }
            else if (number.Last() == '0')
            {
                Console.WriteLine(number + " сорок");
            }
        }
    }
}
