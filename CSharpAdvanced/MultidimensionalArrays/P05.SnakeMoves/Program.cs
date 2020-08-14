using System;
using System.Linq;

namespace P05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int columns = dimentions[1];


            string snakeAsText = Console.ReadLine();
            var matrix = new char[rows, columns];

            CreateMatrix(rows, columns, snakeAsText, matrix);
            ReverseOddRows(rows, columns, matrix);
            PrintMatrix(rows, columns, matrix);
        }

        private static void PrintMatrix(int rows, int columns, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ReverseOddRows(int rows, int columns, char[,] matrix)
        {
            for (int row = 1; row < rows; row += 2)
            {
                for (int col = 0; col < columns / 2; col++)
                {
                    char curr = matrix[row, col];
                    matrix[row, col] = matrix[row, columns - 1 - col];
                    matrix[row, columns - 1 - col] = curr;
                }
            }
        }

        private static void CreateMatrix(int rows, int columns, string snakeAsText, char[,] matrix)
        {
            int currentSymbolOfSnake = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    char currentSymbol = snakeAsText[currentSymbolOfSnake];
                    matrix[row, col] = currentSymbol;
                    currentSymbolOfSnake++;
                    if (currentSymbolOfSnake == snakeAsText.Length)
                    {
                        currentSymbolOfSnake = 0;
                    }

                }
            }
        }
    }
}
