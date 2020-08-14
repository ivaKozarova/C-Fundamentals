using System;
using System.Dynamic;
using System.Linq;

namespace P04.MatrixShuffling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int columns = dimentions[1];

            var matrix = FillMatrix(rows, columns);

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                var cmdArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArg[0];
                if(command == "swap")
                {
                    
                    if(cmdArg.Length == 5)
                    {
                        var row1 = int.Parse(cmdArg[1]);
                        var col1 = int.Parse(cmdArg[2]);
                        var row2 = int.Parse(cmdArg[3]);
                        var col2 = int.Parse(cmdArg[4]);

                        if (row1 >= 0 && row1 <= rows && row2 >= 0 && row2 <= rows
                            && col1 >= 0 && col1 <= columns && col2 >= 0 && col2 <= columns)
                        {
                            var temp = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = temp;

                           PrintMatrix(matrix);
                        }

                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+ ' ');
                }
                Console.WriteLine();
            }
        }
        static string[,] FillMatrix(int rows , int columns)
        {
            var matrix = new string[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
}
