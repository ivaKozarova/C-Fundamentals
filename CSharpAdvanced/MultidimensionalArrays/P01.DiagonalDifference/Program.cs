using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];
            FillMatrix(n, matrix);

            int sumOfPrimaryDiagonal = CalcSumOfPrimaryDiagonal(matrix);
            int sumOfSecondaryDiagonal = CalcSumOfSecondaryDiagonal(matrix);

            int result = Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal);
            Console.WriteLine(result);

            
        }
        private static int CalcSumOfSecondaryDiagonal(int[,] matrix)
        {
            int sumOfDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfDiagonal += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            return sumOfDiagonal;
        }

        private static int CalcSumOfPrimaryDiagonal(int[,] matrix)
        {
            int sumOfDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfDiagonal += matrix[i, i];
            }
            return sumOfDiagonal;
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
