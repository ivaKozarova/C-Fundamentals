using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var even = queue.Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", even));
        }
    }
}
