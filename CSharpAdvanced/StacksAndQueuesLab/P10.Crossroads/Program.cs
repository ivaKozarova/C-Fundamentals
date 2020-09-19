using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();

            int countPassedCars = 0;

            string input;
            bool crash = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int currenGeeenLight = greenLight;
                    while (cars.Any())
                    {
                        {
                            string currentcar = cars.Peek();

                            if (currentcar.Length < currenGeeenLight)
                            {
                                currenGeeenLight -= currentcar.Length;
                                cars.Dequeue();
                                countPassedCars++;
                            }
                            else
                            {
                                int lengthRest = currentcar.Length - currenGeeenLight;
                                if (lengthRest <= freeWindow)
                                {
                                    cars.Dequeue();
                                    countPassedCars++;
                                    break;
                                }
                                else
                                {
                                    string restPartOfCar = currentcar.Substring(currentcar.Length - lengthRest);
                                    char ch = restPartOfCar.ToCharArray()[freeWindow];

                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentcar} was hit at {ch}.");
                                    crash = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                if (crash)
                {
                    break;
                }
            }
           if(!crash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countPassedCars} total cars passed the crossroads.");
            }
        }
    }
}
