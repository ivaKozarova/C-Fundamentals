using System;
using System.Linq;


namespace P07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = CreateMatrix(n);


            
            int knightsToRemove = 0;

            while (true)

            {
                int maxDangerousKnight = 0;
                int currentRowOfKnight = -1;
                int currentColOfKnights = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {

                        if (matrix[row, col] == 'K')
                        {
                            int currentDangerousKnight = FindDangerousCount(n, matrix, row, col);
                            if (currentDangerousKnight > maxDangerousKnight)
                            {
                                maxDangerousKnight = currentDangerousKnight;
                                currentRowOfKnight = row;
                                currentColOfKnights = col;
                            }
                        }
                    }
                }

                if (maxDangerousKnight == 0)
                {
                    break;
                }
                else
                {

                    matrix[currentRowOfKnight, currentColOfKnights] = '0';
                    knightsToRemove++;
                }
            }
            Console.WriteLine(knightsToRemove);
        }

       
        private static int FindDangerousCount(int n, char[,] matrix, int row, int col)
        {
            int currentDangerousKnight = 0;
            if (IsValidPos(row + 1, col + 2, n))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row + 1, col - 2, n))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row - 1, col + 2, n))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row - 1, col - 2, n))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row + 2, col + 1, n))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row + 2, col - 1, n))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row - 2, col + 1, n))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    currentDangerousKnight++;
                }
            }
            if (IsValidPos(row - 2, col - 1, n))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    currentDangerousKnight++;
                }
            }

            return currentDangerousKnight;
        }


        private static bool IsValidPos(int row, int col, int n )
        {
            if(row >= 0 && row < n && col >= 0 && col < n)
            {
                return true;
            }
            return false;
        }

        private static char[,] CreateMatrix(int n)
        {
            var matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine().ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            return matrix;
        }
    }
}
