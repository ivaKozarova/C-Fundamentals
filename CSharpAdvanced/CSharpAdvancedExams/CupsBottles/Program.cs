using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var wasterWater = 0;
            var cups = new Queue<int>(cupsInput);
            var bottles = new Stack<int>(bottlesInput);

            while (cups.Any() && bottles.Any())
            {
                var currCup = cups.Peek();
                var currBottle = bottles.Peek();

                if (currCup > currBottle)
                {
                    while (currCup > 0)
                    {
                        currCup -= currBottle;
                        if (currCup > 0)
                        {
                            bottles.Pop();
                            currBottle = bottles.Peek();
                        }
                        else
                        {
                            wasterWater += Math.Abs(currCup);
                        }

                    }
                }

                else if (currCup < currBottle)
                {
                    wasterWater += (currBottle - currCup);
                }
                cups.Dequeue();
                bottles.Pop();
            }

            if(cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(' ',cups)}");
            }
            else if(bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasterWater}");


        }
    }
}
