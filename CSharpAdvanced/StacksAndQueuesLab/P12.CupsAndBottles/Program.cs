using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            var bottleCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var cups = new Stack<int>(cupsCapacity);
            var bottles = new Stack<int>(bottleCapacity);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Pop();
                int currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {

                    wastedWater += (currentBottle - currentCup);
                }
                else
                {
                    currentCup -= currentBottle;
                    cups.Push(currentCup);
                }
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");


        }
    }
}
