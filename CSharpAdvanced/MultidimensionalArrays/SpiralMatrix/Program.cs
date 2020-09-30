using System;
using System.Collections.Generic;
using System.IO;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int minRow = 0;
            int minCol = 0;
            int maxRow = n - 1;
            int maxCol = n - 1;

            for (int i = n*n; i >= 1; i++)
            {
                for (int col = minCol; col <= maxCol; col++)
                {
                    matrix[minRow, col] = i;
                    i--;
                }
                for (int row = minRow+1; row <= maxRow; row++)
                {
                    matrix[row, maxCol] = i;
                    i--;
                }
                for (int col = maxCol -1; col >= minCol; col--)
                {
                    matrix[maxRow, col] = i;
                    i--;
                }
                for (int row = maxRow -1; row > minRow; row--)
                {
                    matrix[row, minCol] = i;
                    i--;
                }
                minRow++;
                maxRow--;
                minCol++;
                maxCol--;
                i--;
            }
           
            PrintMatrix(matrix);
        }


        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+ "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
