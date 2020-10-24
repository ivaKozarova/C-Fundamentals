using System;

namespace SneakingExamFeb2018
{
    class Program
    {
        class Player
        {
            public Player(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] rooms = new char[n][];
            FillRooms(rooms);
            var player = CheckPlayerPosition(rooms);
            var enemyRow = EnemyRow(rooms);
            bool isNikoladzeKilled = false;
            bool isSamKilled = false;

            string command = Console.ReadLine();

            for (int i = 0; i < command.Length; i++)
            {
                MoveEnemies(rooms);
                isSamKilled = CheckForEnemyOnRow(rooms, player.Row, player.Col);
                if (isSamKilled)
                {
                    break;
                }
                char currentCmd = command[i];
                MovePlayer(rooms, player, currentCmd);

                if (player.Row == enemyRow)
                {
                    KillNikoladze(rooms, enemyRow);
                    isNikoladzeKilled = true;
                    break;
                }
            }
            
            if (isSamKilled)
            {
                Console.WriteLine($"Sam died at {player.Row}, {player.Col}");
                rooms[player.Row][player.Col] = 'X';
            }
            else if(isNikoladzeKilled)
            {
                Console.WriteLine("Nikoladze killed!");
            }
            PrintRooms(rooms);

        }

        private static void MovePlayer(char[][] rooms, Player player, char currentCmd)
        {
            rooms[player.Row][player.Col] = '.';
            if (currentCmd == 'U')
            {
                player.Row--;
            }
            else if (currentCmd == 'D')
            {
                player.Row++;
            }
            else if (currentCmd == 'L')
            {
                player.Col--;
            }
            else if (currentCmd == 'R')
            {
                player.Col++;
            }
            rooms[player.Row][player.Col] = 'S';
        }

        private static bool CheckForEnemyOnRow(char[][] rooms,int playerRow, int playerCol)
        {
             int currentRow = playerRow;
            for (int currentCol = 0; currentCol < rooms[currentRow].Length; currentCol++)
            {
                if(rooms[currentRow][currentCol] == 'b' && currentCol < playerCol)
                {
                    return  true;
                }
                else if(rooms[currentRow][currentCol] == 'd' && currentCol > playerCol)
                {
                    return true;
                }
            }
            return false;
        }
        private static void KillNikoladze(char[][] rooms, int enemyRow)
        {

            for (int col = 0; col < rooms[enemyRow].Length; col++)
            {
                if (rooms[enemyRow][col] == 'N')
                {
                    rooms[enemyRow][col] = 'X';
                    break;
                }
            }
         }
        static void MoveEnemies(char[][] rooms)
        {
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms[row].Length; col++)
                {
                    if (rooms[row][col] == 'b')
                    {
                        if (col == rooms[row].Length - 1)
                        {
                            rooms[row][col] = 'd';

                        }
                        else
                        {
                            rooms[row][col] = '.';
                            rooms[row][col + 1] = 'b';
                        }
                        break;
                    }
                    else if (rooms[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            rooms[row][col] = 'b';
                        }
                        else
                        {
                            rooms[row][col] = '.';
                            rooms[row][col - 1] = 'd';
                        }
                        break;
                    }
                }
            }
        }
        static void PrintRooms(char[][] rooms)
        {
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", rooms[row]));
            }
        }
        static int EnemyRow(char[][] rooms)
        {
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms[row].Length; col++)
                {
                    if (rooms[row][col] == 'N')
                        return row;
                }
            }
            return -1;
        }

        private static Player CheckPlayerPosition(char[][] rooms)
        {
            Player player = null;
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms[row].Length; col++)
                {
                    if (rooms[row][col] == 'S')
                    {
                        player = new Player(row, col);
                        return player;
                    }
                }
            }
            return player;
        }
        static void FillRooms(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

            }
        }
    }
}

