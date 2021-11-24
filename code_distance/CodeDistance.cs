using System.Collections.Generic;

namespace code_distance
{
    public static class CodeDistance
    {
        public static List<int> GetCodeDistance(List<List<int>> H)
        {
            List<int> d = new List<int>();

            for (int i = 0; i < H.Count; i++)
            {
                for (int j = i + 1; j < H.Count; j++)
                {
                    int distance = 0;
                    for (int k = 0; k < H[i].Count; k++)
                    {
                        if (H[i][k] != H[j][k])
                        {
                            distance++;
                        }
                    }
                    d.Add(distance);
                }
            }

            return d;
        }
    }
}