using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var borders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var command = Console.ReadLine();

            Predicate<int> predicate = command == "odd" ?
                (new Predicate<int>(n => n % 2 != 0)) : (new Predicate<int>(n => n % 2 == 0));

            for (int i = borders[0]; i <= borders[1]; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
