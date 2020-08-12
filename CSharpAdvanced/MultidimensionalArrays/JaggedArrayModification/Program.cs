using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];
            FillArray(rows, array);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArg = command.Split();
                RunCommand(cmdArg, array);
            }

            PrintArray(rows, array);

        }

        private static void PrintArray(int rows, int[][] array)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
        }

        private static void RunCommand(string[] cmdArg , int[][] array)
        {
            string action = cmdArg[0];
            int currentRow = int.Parse(cmdArg[1]);
            int currentCol = int.Parse(cmdArg[2]);
            int value = int.Parse(cmdArg[3]);

            if (currentRow >= 0 && currentRow < array.Length
                &&currentCol>= 0 && currentCol < array[currentRow].Length)
            {
                if (action == "Add")
                {

                    array[currentRow][currentCol] += value;
                }


                else if (action == "Subtract")
                {
                    array[currentRow][currentCol] -= value;
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        private static void FillArray(int rows, int[][] array)
        {
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                array[i] = input;
            }
        }
    }
}
