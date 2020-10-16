using System;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();

            int n = int.Parse(Console.ReadLine());
            var field = new char[n][];
            FillTheMatrix(n, field);
            var playerPos = new int[2];
            FindPlayerPosition(n, field, playerPos);
            string cmd;
            while((cmd = Console.ReadLine()) != "end")
            {
                initialString = RunCmd(initialString, n, field, playerPos, cmd);
            }

            Console.WriteLine(initialString);
            field[playerPos[0]][playerPos[1]] = 'P';
            PrintMatrix(field);
        }

        private static void PrintMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("",field[row]));
            }
        }

        private static string RunCmd(string initialString, int n, char[][] field, int[] playerPos, string cmd)
        {
            bool isValid = true;
            field[playerPos[0]][playerPos[1]] = '-';
            if (cmd == "up")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0] - 1, playerPos[1], n);
            }
            else if (cmd == "down")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0] + 1, playerPos[1], n);
            }
            else if (cmd == "left")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0], playerPos[1] - 1, n);
            }
            else if (cmd == "right")
            {
                isValid = ValidateNewPositionOfPlayer(playerPos, playerPos[0], playerPos[1] + 1, n);
            }
            if (isValid)
            {
                if (field[playerPos[0]][playerPos[1]] != '-')
                {
                    var charToAdd = field[playerPos[0]][playerPos[1]];
                    initialString = initialString + charToAdd;
                }
            }
            else
            {
                initialString = initialString.Remove(initialString.Length - 1);
            }

            return initialString;
        }

        static bool ValidateNewPositionOfPlayer(int[] playerPos, int playerRow, int playerCol, int n)
        {
            bool isValidMovement = true;
            if (playerRow >= 0 && playerRow < n
                && playerCol >= 0 && playerCol < n)
            {
                playerPos[0] = playerRow;
                playerPos[1] = playerCol;
                return isValidMovement;
            }
            else
            {
                return false;
            }
        }
       
        private static void FindPlayerPosition(int n, char[][] field, int[] playerPos)
        {
            var isFoundPos = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (field[row][col] == 'P')
                    {
                        playerPos[0] = row;
                        playerPos[1] = col;
                        isFoundPos = true;
                        break;
                    }
                    if(isFoundPos)
                    {
                        return;
                    }
                }
            }
        }
        private static void FillTheMatrix(int n, char[][] field)
        {
            for (int row = 0; row < n; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
