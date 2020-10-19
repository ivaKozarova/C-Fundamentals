using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[n, n];
            CreateFiled(n, field);
            int[] playerPos = FindStartPos(field);
            int countOfCoals = CountOfCoals(field);
            int collectedCoals = 0;


            for (int i = 0; i < commands.Length; i++)
            {
                var currCmd = commands[i];
                field[playerPos[0], playerPos[1]] = '*';

                MovePlayer(field, playerPos, currCmd);

                if(field[playerPos[0],playerPos[1]] == 'c')
                {
                    collectedCoals++;
                    if(countOfCoals - collectedCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerPos[0]}, {playerPos[1]})");
                        break;
                    }
                }
                else if(field[playerPos[0], playerPos[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerPos[0]}, {playerPos[1]})");
                    break;
                }
                else if(i == commands.Length -1)
                {
                    Console.WriteLine($"{countOfCoals - collectedCoals} coals left. ({playerPos[0]}, {playerPos[1]})");
                }
            }

        }

        private static void MovePlayer(char[,] field, int[] playerPos, string currCmd)
        {
            if (currCmd == "up")
            {
                if (playerPos[0] - 1 >= 0)
                {
                    playerPos[0] -= 1;
                }
            }
            else if (currCmd == "down")
            {
                if (playerPos[0] + 1 < field.GetLength(0))
                {
                    playerPos[0] += 1;
                }
            }
            else if (currCmd == "left")
            {
                if (playerPos[1] - 1 >= 0)
                {
                    playerPos[1] -= 1;
                }
            }
            else if (currCmd == "right")
            {
                if (playerPos[1] + 1 < field.GetLength(1))
                {
                    playerPos[1] += 1;
                }
            }
            
        }

        private static int CountOfCoals(char[,] field)
        {
            int count = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'c')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static int[] FindStartPos(char[,] field)
        {
            int[] playerPos = new int[2];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 's')
                    {
                        playerPos[0] = row;
                        playerPos[1] = col;
                        return playerPos;
                    }
                }
            }
            return playerPos;

        }

        private static void CreateFiled(int n, char[,] field)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                }
            }
        }
    }
}
