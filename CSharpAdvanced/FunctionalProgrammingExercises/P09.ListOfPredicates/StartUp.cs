using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var listOfNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToList();

            var divisableNums = GetDivisableNumbers(n, listOfNums);
            Console.WriteLine(string.Join(' ', divisableNums));
            
        }

        static List<int> GetDivisableNumbers(int n , List<int> listOfNumbers)
        {
            var divisableNums = new List<int>();
            

            for (int i = 1; i <= n; i++)
            {
                var isDivisable = true;
                for (int j = 0; j < listOfNumbers.Count; j++)
                {
                    Predicate<int> predicate = x => i % x != 0;
                    if (predicate(listOfNumbers[j]))
                    {
                        isDivisable = false;
                        break;
                    }
                }
                if(isDivisable)
                {
                    divisableNums.Add(i);
                }
            }
            return divisableNums;
        }
    }
}
