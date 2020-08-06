using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var queue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
