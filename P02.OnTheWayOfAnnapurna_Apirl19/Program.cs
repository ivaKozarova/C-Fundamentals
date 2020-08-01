using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.OnTheWayOfAnnapurna_April19
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split("->");
                string command = inputArg[0];
                string store = inputArg[1];
                if (command == "Add")
                {
                    if (!stores.ContainsKey(store))
                    {
                        stores[store] = new List<string>();
                    }
                    string[] items = inputArg[2].Split(",");
                    for (int i = 0; i < items.Length; i++)
                    {
                        string item = items[i];
                        stores[store].Add(item);

                    }
                }

                else if (command == "Remove")
                {
                    if (stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                }

            }

            stores = stores.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Stores list:");
            foreach (var kvp in stores)
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }

    }
}
