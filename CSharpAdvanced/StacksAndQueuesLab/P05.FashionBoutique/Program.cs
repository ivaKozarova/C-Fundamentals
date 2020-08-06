using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            int countOfRacks = 0;
            int currentRackValue = 0;
            while (clothes.Any())
            {
                int currentCloth = clothes.Pop();
                if (currentRackValue + currentCloth < capacity)
                {
                    currentRackValue += currentCloth;
                }

                else if (currentRackValue + currentCloth == capacity)
                {
                    currentRackValue = 0;
                    countOfRacks++;
                }

                else
                {
                    countOfRacks++;
                    currentRackValue = currentCloth;
                }
            }

            if (currentRackValue > 0)
            {
                countOfRacks++;
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
