using System;
using System.Collections.Generic;

namespace P07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var queue = new Queue<string>(input);

            int toss = int.Parse(Console.ReadLine());
            int currPos = 1;
            while(queue.Count > 1)
            {
                string currentName = queue.Dequeue();
                if(currPos == toss)
                {
                    Console.WriteLine($"Removed {currentName}");
                    currPos = 1;
                }
                else
                {
                    queue.Enqueue(currentName);
                    currPos++;
                }
                
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
