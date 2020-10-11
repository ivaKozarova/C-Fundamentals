using System;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
