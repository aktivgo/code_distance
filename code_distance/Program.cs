using System;
using System.Collections.Generic;
using System.IO;

namespace code_distance
{
    internal static class Program
    {
        private const string Path = "../../data_test/";

        public static void Main()
        {
            while (true)
            {
                PrintMenu();
                Console.Write("Выберите пункт меню: ");
                var ch = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                switch (ch)
                {
                    case 0:
                        return;
                    case 1:
                    {
                        Console.Write("Введите название файла: ");
                        string fileName = Console.ReadLine();

                        if (!File.Exists(Path + fileName))
                        {
                            Console.WriteLine("Попробуйте ещё раз\n");
                            break;
                        }

                        Console.WriteLine();
                        PrintCaseOne(fileName);
                    }
                        break;
                    case 2:
                    {
                        Console.Write("Введите название файла: ");
                        string fileName = Console.ReadLine();

                        if (!File.Exists(Path + fileName))
                        {
                            Console.WriteLine("Попробуйте ещё раз\n");
                            break;
                        }

                        Console.WriteLine();
                        PrintCaseTwo(fileName);
                    }
                        break;
                    case 3:
                    {
                        Console.Write("Введите название файла: ");
                        string fileName = Console.ReadLine();

                        if (!File.Exists(Path + fileName))
                        {
                            Console.WriteLine("Попробуйте ещё раз\n");
                            break;
                        }

                        Console.WriteLine();
                        PrintCaseThree(fileName);
                    }
                        break;
                    default:
                        Console.WriteLine("Попробуйте ещё раз\n");
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Найти кодовое расстояние d по множеству кодовых слов");
            Console.WriteLine("2. Найти кодовое расстояние d по порождающей матрице G");
            Console.WriteLine("3. Найти кодовое расстояние d по проверочной матрице Н");
            Console.WriteLine("0. Выход\n");
        }

        private static string ReadFromFile(string fileName)
        {
            FileStream stream = new FileStream(Path + fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string textFromFile = reader.ReadToEnd();
            stream.Close();

            return textFromFile;
        }

        private static List<List<int>> ParseMatrix(string textFromFile)
        {
            string[] matrixStr = textFromFile.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<List<int>> matrix = new List<List<int>>();
            for (int i = 0; i < matrixStr.Length; i++)
            {
                matrix.Add(new List<int>());
                foreach (var item in matrixStr[i])
                {
                    matrix[i].Add(int.Parse(item.ToString()));
                }
            }

            return matrix;
        }

        private static void PrintCaseOne(string fileName)
        {
            string textFromFile = ReadFromFile(fileName);
            Console.WriteLine("Входные данные:\n" + textFromFile + "\n");

            List<List<int>> matrix = ParseMatrix(textFromFile);

            Console.WriteLine("Результат:");
            int d = CodeDistance.GetCodeDistanceA(matrix);
            Console.WriteLine("D = " + d + "\n");
        }

        private static void PrintCaseTwo(string fileName)
        {
            string textFromFile = ReadFromFile(fileName);
            Console.WriteLine("Входные данные:\n" + textFromFile + "\n");

            List<List<int>> matrix = ParseMatrix(textFromFile);

            Console.WriteLine("Результат:");
            int d = CodeDistance.GetCodeDistanceB(matrix);
            Console.WriteLine("D = " + d + "\n");
        }

        private static void PrintCaseThree(string fileName)
        {
            string textFromFile = ReadFromFile(fileName);
            Console.WriteLine("Входные данные:\n" + textFromFile + "\n");

            List<List<int>> matrix = ParseMatrix(textFromFile);

            Console.WriteLine("Результат:");
            int d = CodeDistance.GetCodeDistanceC(matrix);
            Console.WriteLine("D = " + d + "\n");
        }
    }
}