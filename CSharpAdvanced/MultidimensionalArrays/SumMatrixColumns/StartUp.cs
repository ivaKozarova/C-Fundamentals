using System;
using System.Linq;

namespace SumMatrixColumns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int columns = dimentions[1];

            int[,] matrix = new int[rows, columns];
            FillMatrix(rows, columns, matrix);
            PrintSumOfCol(matrix);

        }

        private static void PrintSumOfCol(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfCol += matrix[row, col];
                }
                Console.WriteLine(sumOfCol);
            }
        }

        private static void FillMatrix(int rows, int columns, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
