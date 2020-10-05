using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int n = int.Parse(Console.ReadLine());

            var result = new List<int>();

            Func<List<int>, List<int>> notDivisable = (result =>
              {
                  for (int i = 0; i < numbers.Count; i++)
                  {
                      if (numbers[i] % n != 0)
                      {
                          result.Add(numbers[i]);
                      }
                  }
                  return result;
              });

            Console.WriteLine(string.Join(' ', notDivisable(result)));

        }

    }
}
