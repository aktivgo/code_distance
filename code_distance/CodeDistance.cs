using System;
using System.Collections.Generic;
using System.Linq;

namespace code_distance
{
    public static class CodeDistance
    {
        public static int GetCodeDistanceA(List<List<int>> m)
        {
            List<int> d = GetCodeDistanceHamming(m);
            return GetMin(d);
        }

        public static int GetCodeDistanceB(List<List<int>> m)
        {
            int w = GetMinWeight(m);
            int d = GetCodeDistanceA(m);

            return Math.Min(w, d);
        }

        public static int GetCodeDistanceC(List<List<int>> matrix)
        {
            for (int columns = 1; columns <= matrix[0].Count; columns++)
            {
                List<List<int>> combinations = GenerateCombinations(matrix[0].Count, columns);

                foreach (var combination in combinations)
                {
                    int[] sum = new int[matrix.Count];

                    foreach (var column in combination)
                    {
                        for (int row = 0; row < matrix.Count; ++row)
                        {
                            sum[row] ^= matrix[row][column] - 48;
                        }
                    }

                    if (sum.Sum() == 0)
                    {
                        return columns;
                    }
                }
            }

            return -1;
        }

        private static List<List<int>> GenerateCombinations(int n, int k)
        {
            List<List<int>> combinations = new List<List<int>>();
            int[] comb = new int[k + 1]; // Сочетание

            // Заполнение массива от 0 до k - 1
            for (int i = 0; i < k; i++) 
            {
                comb[i] = i;
            }

            comb[k] = n + 2; // Барьер

            int j = 0;
            // Пока элемент сочетания не больше максимального элемента в исходном множестве
            while (comb[j] < n)
            {
                List<int> res = new List<int>(comb);
                res.RemoveAt(res.Count - 1);
                combinations.Add(res);
                // Если условие всё время выполняется, то цикл упирается в барьер и завершается
                for (j = 0; comb[j] + 1 == comb[j + 1]; j++)
                {
                    comb[j] = j;
                }

                comb[j]++;
            }

            return combinations;
        }

        private static List<int> GetCodeDistanceHamming(List<List<int>> m)
        {
            List<int> d = new List<int>();

            for (int i = 0; i < m.Count; i++)
            {
                for (int j = i + 1; j < m.Count; j++)
                {
                    int distance = 0;
                    for (int k = 0; k < m[i].Count; k++)
                    {
                        if (m[i][k] != m[j][k])
                        {
                            distance++;
                        }
                    }

                    d.Add(distance);
                }
            }

            return d;
        }

        private static int GetMin(List<int> list)
        {
            int min = Int32.MaxValue;
            foreach (var item in list)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        private static List<int> GetWeight(List<List<int>> m)
        {
            List<int> weight = new List<int>();

            foreach (var row in m)
            {
                int w = 0;
                foreach (var col in row)
                {
                    w += col;
                }

                weight.Add(w);
            }

            return weight;
        }

        private static int GetMinWeight(List<List<int>> m)
        {
            List<int> w = GetWeight(m);
            return GetMin(w);
        }

        private static List<int> GetCountOfNullSumCols(List<List<int>> m)
        {
            List<int> c = new List<int>();

            for (int i = 0; i < m[0].Count; i++)
            {
                for (int j = i + 1; j < m[0].Count; j++)
                {
                    int distance = 0;
                    bool isNull = true;
                    for (int k = 0; k < m.Count && isNull; k++)
                    {
                        if (m[k][i] != m[k][j])
                        {
                            isNull = false;
                        }
                    }

                    distance += isNull ? 1 : 0;
                    c.Add(distance);
                }
            }

            return c;
        }
    }
}