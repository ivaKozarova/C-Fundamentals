using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split()
                .Select(double.Parse)
                .ToArray();

            var countNumbers = new Dictionary<double, int>();
            AddNumbersToDic(numbers, countNumbers);

            PrintDictionary(countNumbers);
        }

        private static void PrintDictionary(Dictionary<double, int> countNumbers)
        {
            foreach (var (numberKey, countValue) in countNumbers)
            {
                Console.WriteLine($"{numberKey} - {countValue} times");
            }
        }

        private static void AddNumbersToDic(double[] numbers, Dictionary<double, int> countNumbers)
        {
            foreach (var currentNum in numbers)
            {
                if (!countNumbers.ContainsKey(currentNum))
                {
                    countNumbers[currentNum] = 0;
                }
                countNumbers[currentNum]++;
            }
        }
    }
}
