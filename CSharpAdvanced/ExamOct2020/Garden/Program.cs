using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            var placesForFlowers = new List<int[]>();
            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var position = input.Split().Select(int.Parse).ToArray();
                bool isValid = ValidatePostion(position[0], position[1], matrix);
                if(isValid)
                {
                    placesForFlowers.Add(position);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int i = 0; i < placesForFlowers.Count; i++)
            {
                var currentFlower = placesForFlowers[i];
                var currentRow = currentFlower[0];
                var currentCol = currentFlower[1];
                BloomFlowers(currentRow, currentCol, matrix);
            }

            PrintGarden(matrix);
        }
        static void PrintGarden(int[,]matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }
        }
        private static void BloomFlowers(int currentRow, int currentCol, int[,]matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[currentRow, col] += 1;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, currentCol] += 1;
            }
            matrix[currentRow, currentCol] -= 1;
            
        }
        static bool ValidatePostion(int row, int col, int[,]matrix)
        {
            if(row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }


    }
}
