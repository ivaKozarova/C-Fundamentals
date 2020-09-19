using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            AddCars(n, cars);

            string input; 
            while ((input = Console.ReadLine())!= "End")
            {
                DriveCar(cars, input);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void DriveCar(List<Car> cars, string input)
        {
            var inputArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var carModel = inputArg[1];
            var amountofKm = double.Parse(inputArg[2]);

            Car currentCar = cars.Find(c => c.Model == carModel);
            currentCar.Drive(amountofKm);
        }

        private static void AddCars(int n, List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuel = double.Parse(carInfo[1]);
                double fuelConsumptionFor1Km = double.Parse(carInfo[2]);
                Car car = new Car(model, fuel, fuelConsumptionFor1Km);
                cars.Add(car);
            }
        }
    }
}
