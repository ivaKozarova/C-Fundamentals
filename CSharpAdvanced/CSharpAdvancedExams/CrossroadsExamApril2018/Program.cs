using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossroadsExamApril2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string input;
            var carsQueue = new Queue<string>();
            var countOfSafePassedCars = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    var remainingSecInGreen = greenLight;
                    string currentCar = null;

                    while (remainingSecInGreen > 0 && carsQueue.Any())
                    {
                        currentCar = carsQueue.Dequeue();
                        countOfSafePassedCars++;
                        remainingSecInGreen -= currentCar.Length;
                    }

                    var freeWindowLeft = freeWindow + remainingSecInGreen;
                    if (freeWindowLeft  < 0)
                    {
                        var indexHit = currentCar.Length - Math.Abs(freeWindowLeft);
                        var characterHit = currentCar[indexHit];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                        break;
                    }
                    
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
            }
            if (input == "END")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countOfSafePassedCars} total cars passed the crossroads.");
            }

        }
    }
}
