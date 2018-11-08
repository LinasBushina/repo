using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lab3
{
    class Matrix
    {
        private readonly int n;
        private readonly int m;
        private readonly double alpha;
        private readonly double[,] arr;

        public Matrix(string path)
        {
            using (var sr = new StreamReader(path))
            {
                n = int.Parse(sr.ReadLine());
                m = int.Parse(sr.ReadLine());
                alpha = double.Parse(sr.ReadLine());
                arr = new double[n, m];
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

        // Rритерий Вальда. По строкам ищем минимальное,
        // потом из всех находим максимальное.
        public Tuple<int, double> Wald()
        {
            double max = int.MinValue;
            int maxI = -1;
            for (int i = 0; i < n; i++)
            {
                double min = arr[i, 0];
                for (int j = 1; j < m; j++)
                { min = Math.Min(min, arr[i, j]); }
                if (maxI == -1 || max < min)
                {
                    max = min;
                    maxI = i;
                }
            }
            return new Tuple<int, double>(maxI, max);
        }

        // Критерий Сэвиджа. По строка максимальное
        // число а потом минимальное среди них
        public Tuple<int, double> Savage()
        {
            double[,] r = new double[n, m];
            for (int j = 0; j < m; j++)
            {
                double max = arr[0, j];
                for (int i = 1; i < n; i++)
                { max = Math.Max(max, arr[i, j]); }
                for (int i = 0; i < n; i++)
                { r[i, j] = max - arr[i, j]; }
            }

            double min = int.MaxValue;
            int minI = -1;
            for (int i = 0; i < n; i++)
            {
                double max = r[i, 0];
                for (int j = 1; j < m; j++)
                { max = Math.Max(max, r[i, j]); }
                if (minI == -1 || min > max)
                {
                    min = max;
                    minI = i;
                }
            }
            return new Tuple<int, double>(minI, min);
        }

        public Tuple<int, double> Hurwitz()
        {
            double glob_max = int.MaxValue;
            int glob_maxI = -1;
            for (int i = 0; i < n; i++)
            {
                double min_row = arr[i, 0];
                double max_row = arr[i, 0];
                for (int j = 1; j < m; j++)
                {
                    min_row = Math.Min(min_row, arr[i, j]);
                    max_row = Math.Max(max_row, arr[i, j]);
                }
                double sm = alpha * min_row +
                    (1.0 - alpha) * max_row;
                if (glob_maxI == -1 || glob_max < sm)
                {
                    glob_max = sm;
                    glob_maxI = i;
                }
            }
            return new Tuple<int, double>(glob_maxI, glob_max);
        }

        public Tuple<int, double> Laplace()
        {
            double max = int.MinValue;
            int maxI = -1;
            for (int i = 0; i < n; i++)
            {
                double sm = 0.0;
                for (int j = 0; j < m; j++)
                { sm += arr[i, j]; }
                sm /= m;
                if (maxI == -1 || max < sm)
                {
                    max = sm;
                    maxI = i;
                }
            }
            return new Tuple<int, double>(maxI, max);
        }
    }
}
