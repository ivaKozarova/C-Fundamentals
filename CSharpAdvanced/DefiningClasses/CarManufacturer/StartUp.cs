using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //var tires = new Tire[4]
            //{
            //    new Tire(2002, 2.5),
            //    new Tire(2002, 2.5),
            //    new Tire(2002, 2.4),
            //    new Tire(2002, 2.6)
            //};

            //var engine = new Engine(75, 120);



            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);


            //Console.WriteLine($"{thirdCar.Make} {thirdCar.Model} - engine {thirdCar.Engine.CubicCapacity} " +
            //    $"{thirdCar.Engine.HorsePower}hp" );
            Car car = new Car()
            {
                Make = "vw",
                Model = " golf",
                Year = 2020,
                FuelQuantity = 8.5,
                FuelConsumption = 6.0
            };


            car.Drive(100);
            Console.WriteLine(car.WhoAmI());


        }
    }
}
