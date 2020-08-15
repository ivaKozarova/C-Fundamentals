using System;
using System.ComponentModel;
using System.Linq;

namespace SumMatrixElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
           // int[] dimentions = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            //     .Select(int.Parse)
            //     .ToArray();
            int rows = dimentions[0];
            int columns = dimentions[1];

            

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] elements =Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                //int[] elements = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                // .Select(int.Parse)
                // .ToArray();
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            //var sum = matrix.Cast<int>().Sum();
            
            var sum = 0;
            foreach (int  element in matrix)
            {
                sum += element;
            }
            Console.WriteLine(sum);

        }
    }
}
