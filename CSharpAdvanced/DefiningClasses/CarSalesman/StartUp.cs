using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                AddEngine(engines);
            }

            int m = int.Parse(Console.ReadLine());
            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine currrentEngine = engines.Find(e => e.Model == engineModel);
                Car car  = null;

                if(carInfo.Length == 2)
                {
                    car = new Car(model, currrentEngine);
                }
                
                else if (carInfo.Length == 3)
                {
                    double weight;
                    bool isWeight = double.TryParse(carInfo[2], out weight);
                    if (isWeight)
                    {
                        car = new Car(model, currrentEngine, weight);
                    }
                    else
                    {
                        string color = carInfo[2];
                        car = new Car(model, currrentEngine, color);
                    }
                }
                else if (carInfo.Length == 4)
                {
                    var weight = int.Parse(carInfo[2]);
                    var color = carInfo[3];
                    car = new Car(model, currrentEngine, weight, color);
                    
                }
                cars.Add(car);

            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);

            }

        }
        private static void AddEngine(List<Engine> engines)
        {
            //{model} {power} {displacement} {efficiency}
            var engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Engine engine = null;
            var model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);

            if (engineInfo.Length == 2)
            {
                engine = new Engine(model, power);
           }

            else if (engineInfo.Length == 3)
            {
                int displacement;
                bool isDisplacement = int.TryParse(engineInfo[2], out displacement);
                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else

                {
                    string efficiency = engineInfo[2];
                    engine = new Engine(model, power, efficiency);
                }

            }
            else if (engineInfo.Length == 4)
            {
                int displacement = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];
                engine = new Engine(model, power, displacement, efficiency);
                
            }
            engines.Add(engine);
        }
    }
}
