using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimentions = SplitInput(new[] { ' ', ',' });
            int rows = dimentions[0];
            int columns = dimentions[1];

            var matrix = new int[rows, columns];

            FillMatrix(rows, columns, matrix);

            FindSquareWithMaxSum(matrix);
            
        }
        private static void FindSquareWithMaxSum(int[,] matrix)
        {
            int maxSum = int.MinValue;
            
            int maxRowFirstPoint = -1;
            int maxColFirstPoint = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col]
                                              + matrix[row, col + 1]
                                              + matrix[row + 1, col] 
                                              + matrix[row + 1, col + 1];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRowFirstPoint = row;
                        maxColFirstPoint = col;
                   }
                }
            }

            PrintMaxSquareAndSum(matrix, maxSum, maxRowFirstPoint, maxColFirstPoint);
        }

        private static void PrintMaxSquareAndSum(int[,] matrix, int maxSum, int maxRowFirstPoint, int maxColFirstPoint)
        {
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(matrix[maxRowFirstPoint + row, maxColFirstPoint + col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }

        private static void FillMatrix(int rows, int columns, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] elements = SplitInput(new[] { ' ', ',' });
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }

        private static int[] SplitInput(char[] separators)
        {
            return Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
