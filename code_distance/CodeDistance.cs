using System;
using System.Collections.Generic;

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

        public static int GetCodeDistanceC(List<List<int>> m)
        {
            List<int> d = GetCodeDistanceHamming(m);
            return GetMin(d);
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