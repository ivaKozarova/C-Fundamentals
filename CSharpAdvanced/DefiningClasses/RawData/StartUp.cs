using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            AddCars(n, cars);

            var input = Console.ReadLine();

            if(input == "fragile")
            {
                PrintAllCarsWithCargoFragile(cars);

            }
            else if(input == "flamable")
            {
                PrintAllCarsWithCargoFlamable(cars);
            }

        }

        private static void PrintAllCarsWithCargoFlamable(List<Car> cars)
        {
            var carsWithCargoFlamable = cars.Where(c => c.Cargo.CargoType == "flamable")
                                .Where(c => c.Engine.EnginePower > 250)
                                .ToList();
            foreach (var car in carsWithCargoFlamable)
            {
                Console.WriteLine(car);
            }
        }

        private static void PrintAllCarsWithCargoFragile(List<Car> cars)
        {
            var carsWithCargoFragile = cars
                .Where(c => c.Cargo.CargoType == "fragile"
                         && c.Tires.Any(t=>t.TirePressure < 1))
                         .ToList();
            foreach (var car in carsWithCargoFragile)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static void AddCars(int n, List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} 
                //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}
                //{tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}
                var model = input[0];
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new List<Tire>
               {
                   new Tire(double.Parse(input[5]), int.Parse(input[6])),
                   new Tire(double.Parse(input[7]), int.Parse(input[8])),
                   new Tire(double.Parse(input[9]), int.Parse(input[10])),
                   new Tire(double.Parse(input[11]), int.Parse(input[12]))
               };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
        }
    }
}
