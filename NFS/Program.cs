using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();
                string carName = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                cars[carName] = new List<int>() { mileage, fuel };
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command.Split(" : ");


                if (tokens[0] == "Drive")
                {
                    string nameOfCar = tokens[1];
                    int distance = int.Parse(tokens[2]);
                    int fuelNeed = int.Parse(tokens[3]);

                    if (cars[nameOfCar][1] >= fuelNeed)
                    {
                        cars[nameOfCar][0] += distance; // increase mileage with given distance
                        cars[nameOfCar][1] -= fuelNeed; // decrease its fuel with the given fuel

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

                else if (tokens[0] == "Refuel")
                {
                    string nameOfCar = tokens[1];
                    int fuel = int.Parse(tokens[2]);

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
                else if (tokens[0] == "Revert")
                {
                    string nameOfCar = tokens[1];
                    int kilometers = int.Parse(tokens[2]);

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

               

            }
            cars = cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            //sorted by their mileage in decscending order, then by their name in ascending order, in the following format:

            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value[0]} kms, Fuel in the tank: {kvp.Value[1]} lt.");
            }
        }
    }
}