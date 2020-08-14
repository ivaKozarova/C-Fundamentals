using System;
using System.Data;
using System.Linq;
using System.Numerics;

namespace P06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var array = FillArray(rows);
            ModifyArray(rows, array);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                RunCommand(array, command);
            }

            PrintArrayJagged(rows, array);
        }

        private static void PrintArrayJagged(int rows, double[][] array)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", array[row]));
            }
        }

        private static void RunCommand(double[][] array, string command)
        {
            var cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string cmd = cmdArg[0];
            int currRow = int.Parse(cmdArg[1]);
            int currCol = int.Parse(cmdArg[2]);
            int value = int.Parse(cmdArg[3]);

            if (currRow >= 0 && currRow < array.Length && currCol >= 0 && currCol < array[currRow].Length)
            {
                if (cmd == "Add")
                {
                    array[currRow][currCol] += value;
                }
                else if (cmd == "Subtract")
                {
                    array[currRow][currCol] -= value;
                }
            }
        }

        private static void ModifyArray(int rows, double[][] array)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    for (int col = 0; col < array[row].Length; col++)
                    {
                        array[row][col] *= 2;
                        array[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < array[row].Length; col++)
                    {
                        array[row][col] /= 2;
                    }
                    for (int col = 0; col < array[row + 1].Length; col++)
                    {
                        array[row + 1][col] /= 2;
                    }
                }
            }
        }

        private static double[][] FillArray(int rows)
        {
            var array = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                array[row] = input;
            }
            return array;
        }
    }
}
