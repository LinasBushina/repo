using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicCode
{
    class Polynomial
    {
        private List<int> degrees;

        private Polynomial()
        { this.degrees = new List<int>(); }
        private Polynomial(IEnumerable<int> collection)
        {
            this.degrees = new List<int>(collection);
            degrees = new List<int>(degrees.OrderByDescending(i => i));
        }
        private Polynomial(Polynomial p) : this()
        {
            for (int i = 0; i < p.degrees.Count; i++)
            { degrees.Add(p.degrees[i]); }
        }
        public Polynomial(string bits) : this()
        {
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                { degrees.Add(bits.Length - i - 1); }
            }
        }

        public int GetMaxDegree() { return degrees[0]; }

        public static Polynomial operator *(Polynomial p, int degree)
        {
            Polynomial res = new Polynomial();
            for (int i = 0; i < p.degrees.Count; i++)
            { res.degrees.Add(p.degrees[i] + degree); }
            return res;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        { return new Polynomial(a.degrees.Union(b.degrees)); }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            IEnumerable<int> union = a.degrees.Union(b.degrees);
            IEnumerable<int> intersect = a.degrees.Intersect(b.degrees);
            return new Polynomial(union.Except(intersect));
        }
        
        public static Polynomial operator /(Polynomial a, Polynomial b)
        {
            Polynomial ac = new Polynomial(a);
            while (ac.degrees[0] >= b.degrees[0])
            { ac -= b * (ac.degrees[0] - b.degrees[0]); }
            return ac;
        }

        public override string ToString()
        {
            string res = "";
            res += "x^" + degrees[0];
            for (int i = 1; i < degrees.Count; i++)
            { res += " + x^" + degrees[i]; }
            return res;
        }
    }
}
