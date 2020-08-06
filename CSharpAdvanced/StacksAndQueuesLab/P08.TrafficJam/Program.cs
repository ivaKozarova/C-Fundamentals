using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace P08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            var queue = new Queue<string>();
            int count = 0;

            while((input = Console.ReadLine())!= "end")
            {
                if(input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Any())
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
