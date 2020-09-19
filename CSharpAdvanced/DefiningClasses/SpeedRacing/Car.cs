using System;

namespace SpeedRacing
{
    public class Car
    {

        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance ;

        public Car(string model , double fuel, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TraveledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public void Drive(double amountOfKm)
        {
            var neededFuel = this.FuelConsumptionPerKilometer * amountOfKm ;
           if (this.FuelAmount >= neededFuel)
            {
                this.FuelAmount -= neededFuel;
                this.TraveledDistance += amountOfKm;
            }
           else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}";
        }


    }
}
