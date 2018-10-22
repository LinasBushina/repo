using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cramer_Rule
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix("matrix2.txt");
            Console.WriteLine(m);
        }
    }
}
