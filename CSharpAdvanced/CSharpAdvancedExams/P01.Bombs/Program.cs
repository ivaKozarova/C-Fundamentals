using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputBombEffect = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var bombEffect = new Queue<int>(inputBombEffect);

            var inputBombCasings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var bombCasings = new Stack<int>(inputBombCasings);

            var bombDatura = 0;
            var bombCherry = 0;
            var bombSmokeDecoy = 0;
            bool isPouchFull = false;

            while (bombEffect.Any() && bombCasings.Any())
            {
                int currBombEffect = bombEffect.Peek();
                int currBombCasing = bombCasings.Pop();
                int result = currBombEffect + currBombCasing;

                switch (result)
                {
                    case 40:
                        bombDatura++;
                        bombEffect.Dequeue();
                        break;
                    case 60:
                        bombCherry++;
                        bombEffect.Dequeue();
                        break;
                    case 120:
                        bombSmokeDecoy++;
                        bombEffect.Dequeue();
                        break;
                    default:
                        
                        currBombCasing -= 5;
                        bombCasings.Push(currBombCasing);
                        break;
                }

                if (bombDatura >= 3 && bombCherry >= 3 && bombSmokeDecoy >= 3)
                {
                    isPouchFull = true;
                    break;
                }
            }

            if (isPouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {bombCherry}");
            Console.WriteLine($"Datura Bombs: {bombDatura}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombSmokeDecoy}");
        }
    }
}
