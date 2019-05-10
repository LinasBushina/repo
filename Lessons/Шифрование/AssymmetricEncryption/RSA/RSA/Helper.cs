using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RSA
{
    static class Helper
    {
        private static BitArray SieveOfSundaram(int limit)
        {
            limit /= 2;
            BitArray bits = new BitArray(limit + 1, true);
            for (int i = 1; 3 * i + 1 < limit; i++)
            {
                for (int j = 1; i + j + 2 * i * j <= limit; j++)
                { bits[i + j + 2 * i * j] = false; }
            }
            return bits;
        }

        private static int ApproximateNthPrime(int nn)
        {
            double n = nn;
            double p;
            if (nn >= 7022)
            { p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385); }
            else if (nn >= 6)
            { p = n * Math.Log(n) + n * Math.Log(Math.Log(n)); }
            else if (nn > 0)
            { p = new int[] { 2, 3, 5, 7, 11 }[nn - 1]; }
            else p = 0;
            return (int)p;
        }

        private static List<int> GeneratePrimesSieveOfSundaram(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfSundaram(limit);
            List<int> primes = new List<int>();
            primes.Add(2);
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(2 * i + 1);
                    found++;
                }
            }
            return primes;
        }

        public static int GetRandomPrime()
        { return GeneratePrimesSieveOfSundaram(new Random(DateTime.Now.Millisecond).Next(5, 100)).Last(); }

        public static int GetCoprime(int num)
        {
            int[] fermat = { 65537, 257, 17 };
            foreach (var f in fermat)
            { if (num > f && num % f != 0) return f; }
            return num - 1;
        }

        public static int GetMulInverse(int e, int f)
        {
            List<int> A = new List<int>();
            A.Add(f);
            List<int> B = new List<int>();
            B.Add(e);
            List<int> AmodB = new List<int>();
            List<int> AdivB = new List<int>();
            List<int> X = new List<int>();
            List<int> Y = new List<int>();

            while (true)
            {
                AmodB.Add(A.Last() % B.Last());
                AdivB.Add(A.Last() / B.Last());
                if (AmodB.Last() == 0) break;
                A.Add(B.Last());
                B.Add(AmodB.Last());
            }

            X.Add(0);
            Y.Add(1);
            for (int i = 1; i < A.Count; i++)
            {
                int revI = A.Count - i - 1;
                int xLast = X.Last();
                X.Add(Y.Last());
                Y.Add(xLast - Y.Last() * AdivB[revI]);
            }
            int d = Y.Last();
            return (d % f + f) % f;
        }
    }
}
