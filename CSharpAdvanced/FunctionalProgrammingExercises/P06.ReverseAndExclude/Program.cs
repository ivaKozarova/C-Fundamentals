using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int n = int.Parse(Console.ReadLine());

            var result = new List<int>();

            Func<List<int>, List<int>> notDevisable = result =>
             {
                 for (int i = 0; i < numbers.Count; i++)
                 {
                     if (numbers[i] % n != 0)
                     {
                         result.Add(numbers[i]);
                     }
                 }
                 return result;
             };

            result = notDevisable(result);
            Console.WriteLine(string.Join(' ', result));


        }
    }
}
