using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] arrayPascal = new long[n][];

            FillPascalTriangle(n, arrayPascal);
            PrintPascalTriangle(arrayPascal);
        }

        private static void PrintPascalTriangle(long[][] arrayPascal)
        {
            for (int i = 0; i < arrayPascal.Length; i++)
            {
                Console.WriteLine(string.Join(" ", arrayPascal[i]));
            }
        }

        private static void FillPascalTriangle(int n, long[][] arrayPascal)
        {
            for (int row = 0; row < n; row++)
            {
                arrayPascal[row] = new long[row + 1];
                arrayPascal[row][0] = 1;

                for (int col = 1; col < arrayPascal[row].Length - 1; col++)
                {
                    arrayPascal[row][col] = arrayPascal[row - 1][col - 1] + arrayPascal[row - 1][col];
                }
                arrayPascal[row][row] = 1;
            }
        }
    }
}
