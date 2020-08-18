using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            HashSet<string> carNumbers = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                InOutCars(input, carNumbers);
            }
            PrintParkingLotStatus(carNumbers);
        }

        private static void PrintParkingLotStatus(HashSet<string> carNumbers)
        {
            if (carNumbers.Any())
            {
                Console.WriteLine(string.Join("\n", carNumbers));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }

        private static void InOutCars(string input, HashSet<string> carNumbers)
        {
            var inputArg = input.Split(", ");
            var direction = inputArg[0];
            var carNum = inputArg[1];

            if (direction == "IN")
            {
                carNumbers.Add(carNum);
            }
            else if (direction == "OUT")
            {
                carNumbers.Remove(carNum);
            }
        }
    }
}
