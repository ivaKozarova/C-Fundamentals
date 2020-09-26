using System;

namespace P02.Bee
{

    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beeTerritory = new char[n][];
            CreateBeeTerritory(n, beeTerritory);

            int beeRowPos = -1;
            int beeColPos = -1;
            bool isFound = false;

            for (int row = 0; row < beeTerritory.Length; row++)
            {
                for (int col = 0; col < beeTerritory.Length; col++)
                {
                    if (beeTerritory[row][col] == 'B')
                    {
                        beeRowPos = row;
                        beeColPos = col;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            bool isBeeIn = true;
            int countOfPollinatedFlowers = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                MoveBee(beeTerritory, ref beeRowPos, ref beeColPos, command);

                isBeeIn = CheckIsBeeIn(beeRowPos, beeColPos, n);
                if (isBeeIn)
                {
                    if (beeTerritory[beeRowPos][beeColPos] == 'f')
                    {
                        countOfPollinatedFlowers++;
                    }
                    else if (beeTerritory[beeRowPos][beeColPos] == 'O')
                    {
                        MoveBee(beeTerritory, ref beeRowPos, ref beeColPos, command);
                        isBeeIn = CheckIsBeeIn(beeRowPos, beeColPos, n);
                        if (isBeeIn)
                        {

                            if (beeTerritory[beeRowPos][beeColPos] == 'f')
                            {
                                countOfPollinatedFlowers++;
                            }
                        }
                    }

                    
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

            }
            if(isBeeIn)
            {
                beeTerritory[beeRowPos][beeColPos] = 'B';
              
            }
            if(countOfPollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countOfPollinatedFlowers} flowers!");
            }

            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countOfPollinatedFlowers} flowers more");
            }

            for (int row = 0; row < beeTerritory.Length; row++)
            {
                Console.WriteLine(string.Join("",beeTerritory[row]));
            }
        }

        private static void MoveBee(char[][] beeTerritory, ref int beeRowPos, ref int beeColPos, string command)
        {
            beeTerritory[beeRowPos][beeColPos] = '.';

            if (command == "left")
            {
                beeColPos -= 1;
            }
            else if (command == "right")
            {
                beeColPos += 1;
            }
            else if (command == "up")
            {
                beeRowPos -= 1;
            }
            else if (command == "down")
            {
                beeRowPos += 1;
            }
        }

        private static bool CheckIsBeeIn(int beeRowPos, int beeColPos, int n)
        {
            if (beeRowPos >= 0 && beeRowPos < n && beeColPos >= 0 && beeColPos < n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateBeeTerritory(int n, char[][] beeTeritory)
        {
            for (int row = 0; row < n; row++)
            {
                var inputRow = Console.ReadLine().ToCharArray();
                beeTeritory[row] = inputRow;
            }
        }
    }
}
