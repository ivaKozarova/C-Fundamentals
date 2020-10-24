using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolverExamFeb2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceForBullet = int.Parse(Console.ReadLine());
            var sizeOfBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var totalIntelligence = int.Parse(Console.ReadLine());
            
            int totalUsedBullets = 0;
            while(bullets.Any() && locks.Any())
            {
                totalUsedBullets++;
                if(bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (totalUsedBullets % sizeOfBarrel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }


            }

            if (locks.Count == 0)
            {
                int moneyEarned = totalIntelligence - (totalUsedBullets * priceForBullet);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
           else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
