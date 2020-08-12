using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int columns = dimentions[1];

            var matrix = new char[rows, columns];
            FillMatrix(rows, columns, matrix);

            int counterEquality = CountEquality(matrix);
            Console.WriteLine(counterEquality);
        }
        private static int CountEquality(char[,] matrix)
        {
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col]== matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col]== matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private static void FillMatrix(int rows, int columns, char[,] matrix)
        {
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                var elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int currentCol = 0; currentCol < columns; currentCol++)
                {
                    matrix[currentRow, currentCol] = elements[currentCol];
                }

            }
        }
    }
}
