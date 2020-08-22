using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            var lair = new char[rows][];
            int[] playerPosition = new int[2];

            FillLier(rows, cols, lair, playerPosition);

            bool isDead = false;
            bool isOut = false;

            var action = Console.ReadLine().ToCharArray();
            for (int i = 0; i < action.Length; i++)
            {
                var directions = action[i];
                var empty = '.';
                var bunny = 'B';
                var player = 'P';

                switch (directions)
                {
                    case 'U':
                        if (playerPosition[0] > 0)
                        {
                            isDead = MovePlayerUp(lair, playerPosition, isDead, empty, player);
                        }
                        else
                        {
                            isOut = PlayerOut(lair, playerPosition, empty);
                        }
                        isDead = BunniesSpread(rows, cols, lair, player, bunny, isDead);
                        break;

                    case 'D':
                        if (playerPosition[0] < rows - 1)
                        {
                            isDead = MovePlayerDown(lair, playerPosition, isDead, empty, player);
                        }
                        else
                        {
                            isOut = PlayerOut(lair, playerPosition, empty);
                        }
                        isDead = BunniesSpread(rows, cols, lair, player, bunny, isDead);
                        break;

                    case 'L':
                        if (playerPosition[1] > 0)
                        {
                            isDead = MovePlayerLeft(lair, playerPosition, isDead, empty, player);
                        }
                        else
                        {
                            isOut = PlayerOut(lair, playerPosition, empty);
                        }
                        isDead = BunniesSpread(rows, cols, lair, player, bunny, isDead);
                        break;

                    case 'R':
                        if (playerPosition[1] < cols - 1)
                        {
                            isDead = MovePlayerRight(lair, playerPosition, isDead, empty, player);
                        }
                        else
                        {
                            isOut = PlayerOut(lair, playerPosition, empty);
                        }
                        isDead = BunniesSpread(rows, cols, lair, player, bunny, isDead);
                        break;
                }

                if (isDead == true || isOut == true)
                {
                    break;
                }
            }

            PrintEndStatment(rows, lair, playerPosition, isDead, isOut);

        }

        private static bool MovePlayerRight(char[][] lair, int[] playerPosition, bool isDead, char empty, char player)
        {
            lair[playerPosition[0]][playerPosition[1]] = empty;
            playerPosition[1] = playerPosition[1] + 1;
            if (lair[playerPosition[0]][playerPosition[1]] == empty)
            {
                lair[playerPosition[0]][playerPosition[1]] = player;
            }
            else
            {
                isDead = true;
            }

            return isDead;
        }

        private static bool MovePlayerLeft(char[][] lair, int[] playerPosition, bool isDead, char empty, char player)
        {
            lair[playerPosition[0]][playerPosition[1]] = empty;
            playerPosition[1] = playerPosition[1] - 1;
            if (lair[playerPosition[0]][playerPosition[1]] == empty)
            {
                lair[playerPosition[0]][playerPosition[1]] = player;
            }
            else
            {
                isDead = true;
            }

            return isDead;
        }

        private static bool MovePlayerDown(char[][] lair, int[] playerPosition, bool isDead, char empty, char player)
        {
            lair[playerPosition[0]][playerPosition[1]] = empty;
            playerPosition[0] = playerPosition[0] + 1;
            if (lair[playerPosition[0]][playerPosition[1]] == empty)
            {
                lair[playerPosition[0]][playerPosition[1]] = player;
            }
            else
            {
                isDead = true;
            }

            return isDead;
        }

        private static bool PlayerOut(char[][] lair, int[] playerPosition, char empty)
        {
            bool isOut = true;
            lair[playerPosition[0]][playerPosition[1]] = empty;
            return isOut;
        }

        private static bool MovePlayerUp(char[][] lair, int[] playerPosition, bool isDead, char empty, char player)
        {
            lair[playerPosition[0]][playerPosition[1]] = empty;
            playerPosition[0] = playerPosition[0] - 1;

            if (lair[playerPosition[0]][playerPosition[1]] == empty)
            {
                lair[playerPosition[0]][playerPosition[1]] = player;
            }
            else
            {
                isDead = true;
            }

            return isDead;
        }

        private static void PrintEndStatment(int rows, char[][] lair, int[] playerPosition, bool isDead, bool isOut)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(lair[row]);
            }
            if (isDead == true)
            {
                Console.WriteLine($"dead: {string.Join(" ", playerPosition)}");
            }
            else if (isOut == true)
            {
                Console.WriteLine($"won: {string.Join(" ", playerPosition)}");
            }
        }

        private static bool BunniesSpread(int rows, int cols, char[][] lair, char player, char bunny, bool isDead)
        {
            var bunniesPositions = new List<int[]>();


            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if(lair[currRow][currCol] == bunny)
                    {
                        var coord = new int[2];
                        coord[0] = currRow;
                        coord[1] = currCol;
                        bunniesPositions.Add(coord);
                    }
                    
                }
            }
            for (int i = 0; i < bunniesPositions.Count; i++)
            {
                int row = bunniesPositions[i][0];
                int col = bunniesPositions[i][1];

                {
                    
                        if (row - 1 >= 0)
                        {
                            if (lair[row - 1][col] == player)
                            {
                                isDead = true;
                            }
                        lair[row - 1][col] = bunny;
                        }
                        if (col - 1 >= 0)
                        {
                            if (lair[row][col - 1] == player)
                            {
                                isDead = true;
                            }
                        lair[row][col - 1] = bunny;
                        }
                        if (col + 1 < cols)
                        {
                            if (lair[row][col + 1] == player)
                            {
                                isDead = true;
                            }
                        lair[row][col + 1] = bunny;
                        }

                        if (row + 1 < rows)
                        {
                            if (lair[row + 1][col] == player)
                            {
                                isDead = true;
                            }
                        lair[row + 1][col] = bunny;
                        }
                    
                }
            }

            return isDead;
        }

        private static void FillLier(int rows, int cols, char[][] lair, int[] playerPosition)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();


                if (input.Contains('P'))
                {
                    playerPosition[0] = row;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 'P')
                        {
                            playerPosition[1] = i;
                            break;
                        }
                    }

                }
                for (int col = 0; col < cols; col++)
                {
                    lair[row] = new char[cols];
                    lair[row] = input;
                }
            }
        }
    }
}
