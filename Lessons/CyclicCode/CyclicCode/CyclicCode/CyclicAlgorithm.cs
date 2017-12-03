using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicCode
{
    class CyclicAlgorithm
    {
        public static Polynomial Calc(Polynomial a, Polynomial g)
        {
            Polynomial mul = a * g.GetMaxDegree();
            Polynomial div = mul / g;
            Polynomial sum = mul + div;
            return sum;
        }
    }
}
