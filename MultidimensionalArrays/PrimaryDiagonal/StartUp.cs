using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            FillMatrix(size, matrix);

            PrintSumOfPrimaryDiagonal(matrix);

        }

        private static void PrintSumOfPrimaryDiagonal(int[,] matrix)
        {
            int sumOfPrimaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfPrimaryDiagonal += matrix[i, i];
            }
            Console.WriteLine(sumOfPrimaryDiagonal);
        }
        private static void FillMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
