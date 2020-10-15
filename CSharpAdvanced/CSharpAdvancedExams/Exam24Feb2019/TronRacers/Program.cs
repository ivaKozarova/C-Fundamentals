using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            var playerOne = new int[2];
            var playerTwo = new int[2];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'f')
                    {
                        playerOne[0] = row;
                        playerOne[1] = col;
                    }
                    if (currentRow[col] == 's')
                    {
                        playerTwo[0] = row;
                        playerTwo[1] = col;
                    }
                }
            }
            char symbolPlayerOne = 'f';
            char symbolPlayerTwo = 's';
            bool isEnd = false;
            while (!isEnd)
            {
                string[] cmd = Console.ReadLine().Split();
                var destinationOfPlayerOne = cmd[0];
               var destinationOfPlayerTwo = cmd[1];
               isEnd = Move(destinationOfPlayerOne, playerOne,matrix, symbolPlayerOne);
                if (isEnd)
                {
                    break;
                }
               isEnd = Move(destinationOfPlayerTwo, playerTwo, matrix, symbolPlayerTwo);
            }

            PrintMatrix(matrix);
        }
        public static void PrintMatrix(char[,]matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        public static bool Move(string destination, int[] playerPosition, char[,] matrix, char symbolPlayer)
        {
            bool isEnd = false;
            ChangePositionOfPlayer(destination, playerPosition, matrix);
            if (matrix[playerPosition[0], playerPosition[1]] == '*')
            {
                matrix[playerPosition[0], playerPosition[1]] = symbolPlayer;
            }
            else
            {
                isEnd = true;
                matrix[playerPosition[0], playerPosition[1]] = 'x';
            }
        
            return isEnd;
        }

        private static void ChangePositionOfPlayer(string destination, int[] playerPosition, char[,] matrix)
        {
            if (destination == "up")
            {
                if (playerPosition[0] == 0)
                {
                    playerPosition[0] = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerPosition[0] -= 1;
                }
            }
            else if (destination == "down")
            {
                if (playerPosition[0] == matrix.GetLength(0) - 1)
                {
                    playerPosition[0] = 0;
                }
                else
                {
                    playerPosition[0] += 1;
                }
            }
            else if (destination == "left")
            {
                if (playerPosition[1] == 0)

                {
                    playerPosition[1] = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerPosition[1] -= 1;
                }

            }
            else if (destination == "right")
            {
                if (playerPosition[1] == matrix.GetLength(0) - 1)
                {
                    playerPosition[1] = 0;
                }
                else
                {
                    playerPosition[1] += 1;
                }
            }
        }
    }
}
