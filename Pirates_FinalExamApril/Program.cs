using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P_rates_FinalExamApril
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Sail")
            {
                CreateListOfCities(input, cities);
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArg = cmd.Split("=>");
                if (cmdArg[0] == "Plunder")
                {
                    PlunderTown(cities, cmdArg);
                }
                else if (cmdArg[0] == "Prosper")
                {
                    ProsperTown(cities, cmdArg);
                }
            }
            cities = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var kvp in cities)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
        }

        private static void ProsperTown(Dictionary<string, List<int>> cities, string[] cmdArg)
        {
            int gold = int.Parse(cmdArg[2]);
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                string town = cmdArg[1];
                cities[town][1] += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
            }
        }

        private static void PlunderTown(Dictionary<string, List<int>> cities, string[] cmdArg)
        {
            string town = cmdArg[1];
            int people = int.Parse(cmdArg[2]);
            int gold = int.Parse(cmdArg[3]);
            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
            cities[town][0] -= people;
            cities[town][1] -= gold;
            if (cities[town][0] == 0 || cities[town][1] == 0)
            {
                cities.Remove(town);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }

        private static void CreateListOfCities(string input, Dictionary<string, List<int>> cities)
        {
            string[] inputArg = input.Split("||");
            string city = inputArg[0];
            int population = int.Parse(inputArg[1]);
            int gold = int.Parse(inputArg[2]);

            if (!cities.ContainsKey(city))
            {
                cities[city] = new List<int>() { 0, 0 };
            }
            cities[city][0] += population;
            cities[city][1] += gold;
        }
    }
}
