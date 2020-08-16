using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var citiesInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                AddCityInfo(citiesInfo);
            }

            PrintInfo(citiesInfo);
        }

        private static void PrintInfo(Dictionary<string, Dictionary<string, List<string>>> citiesInfo)
        {
            foreach (var (continentKey, value) in citiesInfo)
            {
                Console.WriteLine($"{continentKey}:");
                foreach (var (countryKey, cityList) in value)
                {
                    Console.WriteLine($"  {countryKey} -> {string.Join(", ", cityList)}");
                }
            }
        }

        private static void AddCityInfo(Dictionary<string, Dictionary<string, List<string>>> citiesInfo)
        {
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (!citiesInfo.ContainsKey(continent))
            {
                citiesInfo[continent] = new Dictionary<string, List<string>>();
            }

            if (!citiesInfo[continent].ContainsKey(country))
            {
                citiesInfo[continent][country] = new List<string>();
            }
               citiesInfo[continent][country].Add(city);
            
        }
    }
}
