using System;
using System.Collections.Generic;

namespace code_distance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество строк матрицы: ");
            int n = int.Parse(Console.ReadLine());

            List<List<int>> H = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                H.Add(new List<int>());

                string line = Console.ReadLine();
                foreach (var item in line)
                {
                    H[i].Add(int.Parse(item.ToString()));
                }
            }

            List<int> d = CodeDistance.GetCodeDistance(H);
            Console.Write("D = ");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }
        }
    }
}