using System;
using System.Collections.Generic;

namespace SpecialCars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var allTires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                AddTires(input, allTires);
            }

            var engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                AddEngine(input, engines);
            }
            var cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                AddCar(input, allTires, engines, cars);
            }

            FindSpecialCar(cars);
        }

        private static void FindSpecialCar(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                double sumOfTiresPressure = 0;

                foreach (var tire in cars[i].Tires)
                {
                    sumOfTiresPressure += tire.Pressure;
                }

                if (cars[i].Year >= 2017 && cars[i].Engine.HorsePowers > 330
                    && sumOfTiresPressure > 9 && sumOfTiresPressure < 10)
                {
                    cars[i].Drive(20);
                    cars[i].PrintCarInfo();

                }
            }
        }

        private static void AddCar(string input, List<Tire[]> allTires, List<Engine> engines, List<Car> cars)
        {
            var carInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string make = carInfo[0];
            string model = carInfo[1];
            int year = int.Parse(carInfo[2]);
            double fuelQuantity = double.Parse(carInfo[3]);
            double fuelConsumption = double.Parse(carInfo[4]);
            int engineIndex = int.Parse(carInfo[5]);
            int tiresIndex = int.Parse(carInfo[6]);

            Car car = new Car(make,
                model,
                year,
                fuelQuantity,
                fuelConsumption,
                engines[engineIndex],
                allTires[tiresIndex]);

            cars.Add(car);
        }

        private static void AddEngine(string input, List<Engine> engines)
        {
            var engineInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int hp = int.Parse(engineInfo[0]);
            double capacity = double.Parse(engineInfo[1]);
            Engine engine = new Engine(hp, capacity);
            engines.Add(engine);
        }

        private static void AddTires(string input, List<Tire[]> allTires)
        {
            int addedTiresCount = 0;
            var tires = new Tire[4];
            var tireInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tireInfo.Length; i += 2)
            {

                if (i % 2 == 0)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    tires[addedTiresCount] = tire;
                    addedTiresCount++;
                }
            }
            allTires.Add(tires);
        }
    }
}
