using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueofIntelligence = int.Parse(Console.ReadLine());

            int bulletCountAtTheBeggining = bullets.Length;
            int countBulletsUsed = 0;

            var stackOfBullets = new Stack<int>(bullets);
            var queueOfLocks = new Queue<int>(locks);

            while (queueOfLocks.Any() && stackOfBullets.Any())
            {
                int currentBullet = stackOfBullets.Pop();
                int currentLock = queueOfLocks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                countBulletsUsed++;
                 if (countBulletsUsed % sizeOfGunBarrel == 0 && stackOfBullets.Any())
                    {
                        Console.WriteLine("Reloading!");
                    }
            }

            if(queueOfLocks.Count == 0)
            {
                
                int earn = (bulletCountAtTheBeggining - stackOfBullets.Count) * priceOfBullet;
                earn = valueofIntelligence - earn;
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${earn}");
            }
            else if(queueOfLocks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
