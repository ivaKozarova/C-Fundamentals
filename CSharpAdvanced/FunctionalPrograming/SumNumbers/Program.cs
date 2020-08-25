using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseToInt = n => int.Parse(n);
            var list = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseToInt)
                .ToList();
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Sum());
        }
    }
}
