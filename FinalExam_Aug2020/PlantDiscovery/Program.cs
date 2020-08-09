using System;
using System.Collections.Generic;
using System.Linq;


namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plants> plants = new Dictionary<string, Plants>();
            AddPlants(n, plants);

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                var cmdArg = input.Split(" ");
                string command = cmdArg[0];
                string plant = cmdArg[1];

                if (plants.ContainsKey(plant))
                {
                    RunCommand(plants, cmdArg, command, plant);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            foreach (var kvp in plants)
            {
                if(kvp.Value.Rating.Count == 0)
                {
                    kvp.Value.Rating.Add(0);
                }
            }

            plants = plants.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Rating.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {(plant.Value.Rating.Average()):f2}");
            }

        }

        private static void RunCommand(Dictionary<string, Plants> plants, string[] cmdArg, string command, string plant)
        {
            if (command == "Rate:")
            {
                AddRate(plants, cmdArg, plant);
            }

            else if (command == "Update:")
            {
                UpdateRarity(plants, cmdArg, plant);
            }

            else if (command == "Reset:")
            {
                ResetRatingList(plants, plant);
            }
        }

        private static void ResetRatingList(Dictionary<string, Plants> plants, string plant)
        {
            plants[plant].Rating.Clear();
        }

        private static void UpdateRarity(Dictionary<string, Plants> plants, string[] cmdArg, string plant)
        {
            int rarity = int.Parse(cmdArg[3]);
            plants[plant].Rarity = rarity;
        }

        private static void AddRate(Dictionary<string, Plants> plants, string[] cmdArg, string plant)
        {
            int rating = int.Parse(cmdArg[3]);
            plants[plant].Rating.Add(rating);
        }

        private static void AddPlants(int n, Dictionary<string, Plants> plants)
        {
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split("<->");
                string plant = info[0];
                int rarity = int.Parse(info[1]);
                if (!plants.ContainsKey(plant))
                {
                    Plants currentPlant = new Plants(rarity);
                    plants[plant] = currentPlant;
                    
                }
                else
                {
                    plants[plant].Rarity = rarity;
                }
            }
        }
    }
    class Plants
    {
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }

        public Plants (int rarity)
        {
           
            this.Rarity = rarity;
            this.Rating = new List<int>();
        }
    }
}
