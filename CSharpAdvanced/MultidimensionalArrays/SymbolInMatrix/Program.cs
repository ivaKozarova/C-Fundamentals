using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            FillMatrix(n, matrix);

            char symbol = char.Parse(Console.ReadLine());
            SearchForSymbol(n, matrix, symbol);
        }

        private static void SearchForSymbol(int n, int[,] matrix, char symbol)
        {
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound == true)
                {
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
