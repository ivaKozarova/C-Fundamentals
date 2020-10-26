using System;
using System.IO;
using System.Linq;

namespace ParkingFeudExamApril2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = info[0] * 2 - 1;
            var cols = info[1] + 2;
            var parking = new string[rows, cols];
            CreateParking(parking);
            int entranceOfSam = int.Parse(Console.ReadLine());
            bool isPark = false;
            int countMovements = 0;

            while (!isPark)
            {
                var places = Console.ReadLine().Split().ToList();
                var placeOfSam = places[entranceOfSam - 1];
                places[entranceOfSam - 1] = "X";
                int pathOfSam = CalcPath(parking, placeOfSam, entranceOfSam);
                if (places.Contains(placeOfSam))
                {
                    var palceOfAnotherDriver = placeOfSam;
                    var entranceOfAnotherDriver = places.IndexOf(palceOfAnotherDriver) + 1;
                    int pathOfAnotherDirver = CalcPath(parking, palceOfAnotherDriver, entranceOfAnotherDriver);
                    if (pathOfAnotherDirver < pathOfSam)
                    {
                        countMovements += pathOfSam * 2;
                        continue;
                    }
                }

                countMovements += pathOfSam;
                Console.WriteLine($"Parked successfully at {placeOfSam}.");
                Console.WriteLine($"Total Distance Passed: {countMovements}");
                isPark = true;


            }

        }
        static int CalcPath(string[,] matrix, string placeToGo, int entrance)
        {
            int path = 0;
            int placeRow = int.Parse(placeToGo[1].ToString());
            int placeCol = (int)placeToGo[0] - 64;

            if (entrance == placeRow || entrance == placeRow + 1 || entrance == placeRow -1)
            {
                path = placeCol;
            }
            else
            {
                int differentBetweenRows = Math.Abs(placeRow - entrance);
                int countMove = differentBetweenRows * (matrix.GetLength(1) + 1);
                int colOnCurrRow = 0;
                if (differentBetweenRows % 2 == 0)
                {
                    colOnCurrRow = placeCol;
                }
                else
                {
                    colOnCurrRow = matrix.GetLength(1) - 1 - placeCol;
                }
               
                path = countMove + colOnCurrRow;
            }
            return path;


        }

        static void CreateParking(string[,] parking)
        {
            for (int row = 0; row < parking.GetLength(0); row++)
            {
                for (int col = 0; col < parking.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        if (col == 0 || col == parking.GetLength(1) - 1)
                        {
                            parking[row, col] = "-";
                        }
                        else
                        {
                            parking[row, col] = "F";
                        }
                    }
                    else
                    {
                        if (col == 0 || col == parking.GetLength(1) - 1)
                        {
                            parking[row, col] = "E";
                        }
                        else
                        {
                            parking[row, col] = "-";
                        }
                    }
                }
            }
        }
        private static void Print(string[,] parking)
        {
            for (int row = 0; row < parking.GetLength(0); row++)
            {
                for (int col = 0; col < parking.GetLength(1); col++)
                {
                    Console.Write(parking[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
