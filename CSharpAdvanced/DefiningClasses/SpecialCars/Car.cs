using System;

namespace SpecialCars
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string make, string model, int year, double fuelQuantity,
            double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;

        }

        public  double Drive(int distance)
        {
            double neededFuel = this.FuelConsumption * distance / 100;
            if(this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
            }
            return this.FuelQuantity;
        }
        public void PrintCarInfo()
        {
            Console.WriteLine($"Make: {this.Make}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Year: {this.Year}");
            Console.WriteLine($"HorsePowers: {this.Engine.HorsePowers}");
            Console.WriteLine($"FuelQuantity: {this.FuelQuantity}");
        }
    }
}
