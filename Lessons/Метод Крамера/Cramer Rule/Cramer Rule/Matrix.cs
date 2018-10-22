using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cramer_Rule
{
    class Matrix
    {
        private readonly int n;
        private double[,] arr;
        private double alphaV;
        private double betaV;
        private double[] xs;
        private double[] ys;

        public Matrix(string path)
        {
            using (var sr = new StreamReader(path))
            {
                n = int.Parse(sr.ReadLine());
                arr = new double[n, n];
                xs = new double[n];
                ys = new double[n];
                string line;
                int i = 0, j = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    j = 0;
                    foreach (var num in line.Split(' '))
                    { arr[i, j++] = int.Parse(num.Trim()); }
                    i++;
                }
            }
        }

        private int _SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0) return 1;
            else return -1;
        }

        private double[,] _CreateSmallerMatrix(double[,] matrix, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(matrix.Length).ToString());
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    { if (n != j) output[x, y++] = matrix[m, n]; }
                }
                else x--;
            }
            return output;
        }

        private double _Determinant(double[,] matrix)
        {
            int order = int.Parse(System.Math.Sqrt(matrix.Length).ToString());
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] Temp = _CreateSmallerMatrix(matrix, 0, j);
                    value = value + matrix[0, j] * (_SignOfElement(0, j) * _Determinant(Temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]));
            }
            else
            {
                return (matrix[0, 0]);
            }
        }

        private double GetMaxMin()
        {
            double max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                double min = arr[i, 0];
                for (int j = 1; j < n; j++)
                { min = Math.Min(min, arr[i, j]); }
                max = Math.Max(max, min);
            }
            return max;
        }

        private double GetMinMax()
        {
            double min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                double max = arr[i, 0];
                for (int j = 1; j < n; j++)
                { max = Math.Max(max, arr[i, j]); }
                min = Math.Min(min, max);
            }
            return min;
        }

        public void _CaclCramer(double[] ans)
        {
            double dets_sum = 0;
            double[] dets = new double[n];
            for (int i = 0; i < n; i++)
            {
                double[,] arr_cpy = arr.Clone() as double[,];
                for (int j = 0; j < n; j++)
                { arr_cpy[j, i] = 1.0; }
                dets[i] = _Determinant(arr_cpy);
                dets_sum += dets[i];
            }
            for (int i = 0; i < n; i++)
            { ans[i] = dets[i] / dets_sum; }
        }

        private double _CalcV(double[] coef)
        {
            double v = 0.0;
            for (int i = 0; i < n; i++)
            { v += arr[0, i] * coef[i]; }
            return v;
        }

        private void CaclCramer()
        {
            _CaclCramer(ys);
            betaV = _CalcV(ys);
            //transpose
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double t = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = t;
                }
            }
            _CaclCramer(xs);
            alphaV = _CalcV(xs);
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                { res += arr[i, j] + " "; }
                res += "\n";
            }

            double alpha = GetMaxMin();
            double beta = GetMinMax();
            res += $"alpha = {alpha}\t";
            res += $"beta  = {beta}\n";
            res += $"IsSadlePoint = {alpha == beta}\n";
            if (alpha == beta) return res;

            CaclCramer();
            res += $"alpha_v = {alphaV}\t";
            res += $"beta_v  = {betaV}\n";

            for (int i = 0; i < n; i++)
            { res += $"{xs[i]}\t{ys[i]}\n"; }

            return res;
        }
    }
}
