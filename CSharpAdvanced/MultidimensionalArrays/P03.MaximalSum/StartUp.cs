using System;
using System.Linq;

namespace P03.MaximalSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();

            var rows = dimentions[0];
            var columns = dimentions[1];

            var matrix = new int[rows, columns];
            ReadIntMatrix(rows, columns, matrix);

            FindMaxSum(matrix);
        }

        static void FindMaxSum(int[,] matrix)
        {
            int sum = int.MinValue;
            int startRowIndex = -1;
            int startColIndex = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    currentSum += matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    currentSum += matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }
            Console.WriteLine("Sum = {0}", sum);
            PrintMaxMatrix(matrix, startRowIndex, startColIndex);
        }

        static void PrintMaxMatrix(int[,] matrix, int row, int col)
        {
            for (int currentRow = row; currentRow <= row + 2; currentRow++)
            {
                for (int currentCol = col; currentCol <= col + 2; currentCol++)
                {
                    Console.Write(matrix[currentRow, currentCol] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadIntMatrix(int rows, int columns, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
