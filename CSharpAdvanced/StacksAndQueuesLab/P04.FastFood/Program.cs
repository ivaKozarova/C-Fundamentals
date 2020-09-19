using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split().Select(int.Parse);
            var orders = new Queue<int>(input);
            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int currentOrder = orders.Peek();
                if (quantityOfFood >= currentOrder)
                {
                    quantityOfFood -= currentOrder;
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
