using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var houses = new char[n][];
            FillTheMatrix(n, houses);
            var santasPos = new int[2];
            FindPositionsOfSanta(houses, santasPos);
            var totalNiceKids = CountNiceKids(houses);
            string cmd;
           
            while ((cmd = Console.ReadLine()) != "Christmas morning")
            {
                houses[santasPos[0]][santasPos[1]] = '-';

                if (cmd == "up")
                {
                    presents = MoveSanta(santasPos, santasPos[0] - 1, santasPos[1], houses, presents);
                }
                else if (cmd == "down")
                {
                    presents = MoveSanta(santasPos, santasPos[0] + 1, santasPos[1], houses, presents);
                }
                else if (cmd == "left")
                {
                    presents = MoveSanta(santasPos, santasPos[0], santasPos[1] - 1, houses, presents);
                }
                else if (cmd == "right")
                {
                    presents = MoveSanta(santasPos, santasPos[0], santasPos[1] + 1, houses, presents);
                }
                if (presents <= 0)
                {
                    break;
                }
            }
            if(presents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            houses[santasPos[0]][santasPos[1]] = 'S';
            PrintHouses(houses);

            var niceKidsLeft = CountNiceKids(houses);
            if(niceKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {totalNiceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsLeft} nice kid/s.");
            }

        }
        private static int CountNiceKids(char[][]houses)
        {
            int niceKids = 0;
            for (int row = 0; row < houses.Length; row++)
            {
                for (int col = 0; col < houses.Length; col++)
                {
                    if(houses[row][col] == 'V')
                    {
                        niceKids++;

                    }
                }
            }
            return niceKids;
        }
        private static void PrintHouses(char[][]houses)
        {
            for (int row = 0; row < houses.Length; row++)
            {
                for (int col = 0; col < houses.Length; col++)
                {
                    Console.Write(houses[row][col]);
                    Console.Write(' ');
                    

                }
                Console.WriteLine();
            }
        }

        private static int MoveSanta(int[] santaPos, int currRow, int currCol, char[][] houses, int presents)
        {
            if (houses[currRow][currCol] == 'V')
            {
                presents--;
            }
            else if (houses[currRow][currCol] == 'C')
            {
                int givenPresents = CheckHousesAround(houses, currRow, currCol);
                presents -= givenPresents;
            }
            santaPos[0] = currRow;
            santaPos[1] = currCol;
            return presents;
        }
        private static int CheckHousesAround(char[][] houses, int currRow, int currCol)
        {
            int givenPresents = 0;
            if (houses[currRow - 1][currCol] == 'X' || houses[currRow - 1][currCol] == 'V')
            {
                givenPresents++;
                houses[currRow - 1][currCol] = '-';

            }
            if (houses[currRow + 1][currCol] == 'X' || houses[currRow + 1][currCol] == 'V')
            {
                givenPresents++;
                houses[currRow + 1][currCol] = '-';
            }
            if (houses[currRow][currCol + 1] == 'X' || houses[currRow][currCol + 1] == 'V')
            {
                givenPresents++;
                houses[currRow][currCol + 1] = '-';
            }
            if (houses[currRow][currCol - 1] == 'X' || houses[currRow][currCol - 1 ] == 'V')
            {
                givenPresents++;
                houses[currRow][currCol - 1] = '-';
            }

            return givenPresents;
        }

        private static void FindPositionsOfSanta(char[][] houses, int[] santasPos)
        {
            for (int row = 0; row < houses.Length; row++)
            {
                for (int col = 0; col < houses.Length; col++)
                {
                    if (houses[row][col] == 'S')
                    {
                        santasPos[0] = row;
                        santasPos[1] = col;
                    }

                }
            }
        }


        private static void FillTheMatrix(int n, char[][] houses)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var inputAsString = String.Empty;
                for (int i = 0; i < input.Length; i++)
                {
                    inputAsString += input[i];
                }
                var currRow = inputAsString.ToCharArray();
                houses[row] = currRow;
            }
        }

    }
}
