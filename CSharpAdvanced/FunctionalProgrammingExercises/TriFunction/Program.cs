using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int> getAsciiSum = p => p.Select(c => (int)c).Sum();

            Func<string[], int, Func<string, int>, string> name = (names, n, getAsciiSum)
                 => names.FirstOrDefault(p => getAsciiSum(p) >= n);
            Console.WriteLine(name(names, n, getAsciiSum));

        }

        
    }
}
