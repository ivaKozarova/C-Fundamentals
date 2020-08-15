using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace P08.Bombs
{
    class Startup
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            FillMatrix(n);

            var bombsPos = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsPos.Length; i++)
            {
                var currentBomb = bombsPos[i].Split(",").Select(int.Parse).ToArray();
                int row = currentBomb[0];
                int col = currentBomb[1];

                int valueOfCurrBomb = matrix[row, col];

                BombExplodes(row, col, valueOfCurrBomb, n);
            }
            int countAliveCells = 0;
            int sumAliveCells = 0;
            foreach (var element in matrix)
            {
                if (element > 0)
                {
                    countAliveCells++;
                    sumAliveCells += element;
                }
            }

            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintMatrix(n);

        }

        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombExplodes(int row, int col, int damage, int n)
        {
            if (damage > 0)
            {
                ValidateCoordinates(row - 1, col - 1, damage ,n);
                ValidateCoordinates(row - 1, col, damage, n);
                ValidateCoordinates(row - 1, col + 1, damage, n);
                ValidateCoordinates(row, col - 1, damage, n);
                ValidateCoordinates(row, col + 1, damage, n);
                ValidateCoordinates(row + 1, col - 1, damage, n);
                ValidateCoordinates(row + 1, col, damage, n);
                ValidateCoordinates(row + 1, col + 1, damage, n);
                matrix[row, col] -= damage;
            }
        }

        private static void ValidateCoordinates(int row, int col, int damage, int n)
        {
            if(row >= 0 && row < n 
           && col >= 0 && col < n
           && matrix[row, col] > 0)
            {
                matrix[row, col] -= damage;
            }
        }

        private static void FillMatrix(int n)
        {
            matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            
        }
    }
}
