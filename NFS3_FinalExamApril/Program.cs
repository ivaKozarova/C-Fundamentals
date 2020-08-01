using System;
using System.Collections.Generic;
using System.Linq;

namespace NFS3_FinalExamApril
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                CreateCollectionOfCars(cars);
            }
            string cmd;

            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdArg = cmd.Split(" : ");
                string nameOfCar = cmdArg[1];
                if (cmdArg[0] == "Drive")
                {
                    DriveCar(cars, cmdArg, nameOfCar);
                }
                else if (cmdArg[0] == "Refuel")
                {
                    RefuelCar(cars, cmdArg, nameOfCar);
                }
                else if (cmdArg[0] == "Revert")
                {
                    RevertCar(cars, cmdArg, nameOfCar);
                }
            }
            cars = cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value[0]} kms, Fuel in the tank: {kvp.Value[1]} lt.");
            }
           
        }

        private static void CreateCollectionOfCars(Dictionary<string, List<int>> cars)
        {
            string[] input = Console.ReadLine().Split('|').ToArray();
            string carName = input[0];
            int mileage = int.Parse(input[1]);
            int fuel = int.Parse(input[2]);
            cars[carName] = new List<int>() { mileage, fuel };
        }

        private static void RevertCar(Dictionary<string, List<int>> cars, string[] cmdArg, string nameOfCar)
        {
            int kilometers = int.Parse(cmdArg[2]);
            if (cars[nameOfCar][0] - kilometers >= 10000)
            {
                cars[nameOfCar][0] -= kilometers;
                Console.WriteLine($"{nameOfCar} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                cars[nameOfCar][0] = 10000;
            }
        }

        private static void RefuelCar(Dictionary<string, List<int>> cars, string[] cmdArg, string nameOfCar)
        {
            int fuel = int.Parse(cmdArg[2]);
            if (cars[nameOfCar][1] + fuel <= 75)
            {
                cars[nameOfCar][1] += fuel;
            }
            else
            {
                fuel = 75 - cars[nameOfCar][1];
                cars[nameOfCar][1] = 75;
            }
            Console.WriteLine($"{nameOfCar} refueled with {fuel} liters");
        }

        private static void DriveCar(Dictionary<string, List<int>> cars, string[] cmdArg, string nameOfCar)
        {
            int distance = int.Parse(cmdArg[2]);
            int fuelNeed = int.Parse(cmdArg[3]);
            if (cars[nameOfCar][1] >= fuelNeed)
            {
                cars[nameOfCar][0] += distance;
                cars[nameOfCar][1] -= fuelNeed;
                Console.WriteLine($"{nameOfCar} driven for {distance} kilometers. {fuelNeed} liters of fuel consumed.");

                if (cars[nameOfCar][0] >= 100000)
                {
                    Console.WriteLine($"Time to sell the {nameOfCar}!");
                    cars.Remove(nameOfCar);
                }
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }
    }
}
