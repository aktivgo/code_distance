using System;
using System.Collections.Generic;

namespace code_distance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество строк матрицы: ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);

            List<List<int>> matrix = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                matrix.Add(new List<int>());

                string line = Console.ReadLine();
                if (line == null) continue;
                foreach (var item in line)
                {
                    matrix[i].Add(int.Parse(item.ToString()));
                }
            }

            int dA = CodeDistance.GetCodeDistanceA(matrix);
            Console.WriteLine("D(a) = " + dA);

            int dB = CodeDistance.GetCodeDistanceB(matrix);
            Console.Write("D(b) = " + dB);
        }
    }
}