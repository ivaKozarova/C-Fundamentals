using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var lilies = new Stack<int>(inputLilies);
            var inputRoses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var roses = new Queue<int>(inputRoses);

            int countOfWreaths = 0;

            int storedFlowers = 0;
            CraftingFlowers(lilies, roses, ref countOfWreaths, ref storedFlowers);

            int extraWreaths = storedFlowers / 15;
            countOfWreaths += extraWreaths;

            PrintResult(countOfWreaths);
        }

        private static void CraftingFlowers(Stack<int> lilies, Queue<int> roses, ref int countOfWreaths, ref int storedFlowers)
        {
            while (lilies.Any() && roses.Any())
            {
                int currSumOfFlowers = 0;
                currSumOfFlowers = lilies.Peek() + roses.Peek();
                if (currSumOfFlowers <= 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    if (currSumOfFlowers < 15)
                    {
                        storedFlowers += currSumOfFlowers;
                    }
                    else if (currSumOfFlowers == 15)
                    {
                        countOfWreaths++;
                    }

                }
                else
                {
                    int currLiliy = lilies.Pop() - 2;
                    lilies.Push(currLiliy);
                }
            }
        }

        private static void PrintResult(int countOfWreaths)
        {
            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }
    }
}
