using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;
        public string Make
        {
            get { return make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
           

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        //public Engine Engine { get; set; }

        //public Tire[] Tires { get; set; }

        //public Car(string make,
        //    string model,
        //    int year,
        //    double quantity,
        //    double consumption,
        //    Engine engine,
        //    Tire[] tires)
        //    :this(make,model,year,quantity,consumption)
        //{
        //    this.Engine = engine;

        //    this.Tires = tires;
        //}

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double quantity, double consumption)
            : this(make, model, year)
        {
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }

        public void Drive(double distance)
        {
            double ramainFuel = this.FuelQuantity - (distance * this.FuelConsumption / 100);

            if (ramainFuel >= 0)
            {
                this.FuelQuantity = ramainFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: { this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}"); 
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");

            return sb.ToString();
        }

    }
}
