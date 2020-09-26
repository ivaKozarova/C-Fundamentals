using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse);
            Queue<int> firstBox = new Queue<int>(firstLine);
            var secondLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            Stack<int> secondBox = new Stack<int>(secondLine);

            var claimedItems = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                var currSumOfItems = firstBox.Peek() + secondBox.Peek();
                if (currSumOfItems % 2 == 0)
                {
                    claimedItems += currSumOfItems;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if(firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if(secondBox.Count == 0 )
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if(claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
